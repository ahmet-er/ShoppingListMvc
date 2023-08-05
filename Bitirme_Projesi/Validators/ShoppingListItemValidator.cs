using Bitirme_Model.Entities;
using FluentValidation;

namespace Bitirme_Projesi.Validators
{
    public class ShoppingListItemValidator : AbstractValidator<ShoppingListItem>
    {
        public ShoppingListItemValidator()
        {
            RuleFor(s => s.Description).MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olmalıdır.");

            RuleFor(s => s.Amount).NotEmpty().WithMessage("Ürün miktarı boş bırakılamaz.");
        }
    }
}
