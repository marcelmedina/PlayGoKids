using CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Command;
using FluentValidation;

namespace CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Validator
{
    public class AddOrUpdateProductCommandValidator : AbstractValidator<AddOrUpdateProductCommand>
    {
        public AddOrUpdateProductCommandValidator()
        {
            RuleFor(command => command.ProductRequestDto.Name).NotNull().NotEmpty()
                .WithMessage("Please specify a name");
            RuleFor(command => command.ProductRequestDto.Sku).NotNull().NotEmpty().Length(3, 10);
            RuleFor(command => command.ProductRequestDto.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(command => command.ProductRequestDto.Price).NotEqual(0)
                .When(command => command.ProductRequestDto.Quantity > 0).WithMessage("Please specify a price");
        }
    }
}
