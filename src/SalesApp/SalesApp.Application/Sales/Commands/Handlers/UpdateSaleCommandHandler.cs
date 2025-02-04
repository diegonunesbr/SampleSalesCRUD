﻿using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Commands.Handlers
{
    internal class UpdateSaleCommandHandler: IRequestHandler<UpdateSaleCommand, Result<Sale>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;
        private readonly IValidator<UpdateSaleCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateSaleCommandHandler(
            IUnitOfWork unitOfWork,
            ISaleRepository saleRepository,
            IValidator<UpdateSaleCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _saleRepository = saleRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Sale>> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Sale? sale = await _saleRepository.GetById(command.id);
                if(sale == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Sale not found", $"There is no sale with id {command.id}");
                }

                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                _mapper.Map(command, sale);
                sale.CalculateSaleDiscount();

                _saleRepository.Update(sale);
                await _unitOfWork.CommitAsync();

                return sale;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
