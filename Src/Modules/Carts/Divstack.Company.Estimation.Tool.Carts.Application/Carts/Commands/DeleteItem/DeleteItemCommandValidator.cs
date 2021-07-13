using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.DeleteItem
{
    public sealed class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteItemCommandValidator()
        {
            RuleFor(cart => cart.ProductId).NotNull().NotEmpty();
        }
    }
}