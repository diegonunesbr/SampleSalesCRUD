using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Commands.Handlers
{
    internal class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, Result<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IValidator<CreateProductCommand> _validator;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IValidator<CreateProductCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Product>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                Product product = _mapper.Map<Product>(command);

                _productRepository.Add(product);
                await _unitOfWork.CommitAsync();

                return product;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
