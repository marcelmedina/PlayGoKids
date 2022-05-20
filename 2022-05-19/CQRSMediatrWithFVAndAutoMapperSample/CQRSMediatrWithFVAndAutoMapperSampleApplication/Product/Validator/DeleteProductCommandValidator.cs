using CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Command;
using FluentValidation;

namespace CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Validator
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Sku).NotNull().NotEmpty().Length(3, 10);
        }
    }
}
