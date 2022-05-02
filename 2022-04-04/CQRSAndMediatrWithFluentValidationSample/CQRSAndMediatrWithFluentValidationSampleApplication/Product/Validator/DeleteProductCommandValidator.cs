using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Command;
using FluentValidation;

namespace CQRSAndMediatrWithFluentValidationSampleApplication.Product.Validator
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Sku).NotNull().NotEmpty().Length(3, 10);
        }
    }
}
