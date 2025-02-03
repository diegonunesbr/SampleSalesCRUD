using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Commands.Handlers
{
    internal class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, Result<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IValidator<UpdateProductCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IValidator<UpdateProductCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Product>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Product? product = await _productRepository.GetById(command.id);
                if(product == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Product not found", $"There is no product with id {command.id}");
                }

                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                _mapper.Map(command, product);

                _productRepository.Update(product);
                await _unitOfWork.CommitAsync();

                return product;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
