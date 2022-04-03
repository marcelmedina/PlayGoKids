using FluentValidation;

namespace FluentValidationSample.Models
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            When(model => model == null, () =>
            {
                RuleFor(model => model).NotNull();
            }).Otherwise(() =>
            {
                RuleFor(model => model.Sku).NotNull();
                RuleFor(model => model.Sku).NotEmpty().Length(3, 10);
                RuleFor(model => model.Quantity).NotEqual(0);
            });
        }
    }
}
