using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.AddItem
{
    public sealed class AddItemCommandValidator : AbstractValidator<AddItemCommand>
    {
        public AddItemCommandValidator()
        {
            RuleFor(cart => cart.Quantity).NotNull().NotEmpty()
                .Must(quantity => quantity.Value > 0)
                .WithMessage("Quantity must be greater than 0");
            RuleFor(cart => cart.ProductId).NotNull().NotEmpty();
        }
    }
}
