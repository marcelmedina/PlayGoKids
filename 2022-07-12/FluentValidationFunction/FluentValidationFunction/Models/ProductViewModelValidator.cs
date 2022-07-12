using FluentValidation;

namespace FluentValidationFunction.Models
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty().WithMessage("Please specify a name");
            RuleFor(model => model.Sku).NotNull().NotEmpty().Length(3, 10);
            RuleFor(model => model.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(model => model.Price).NotEqual(0).When(model => model.Quantity > 0)
                .WithMessage("Please specify a price");
        }
    }
}
