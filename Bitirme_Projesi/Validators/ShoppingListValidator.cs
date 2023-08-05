using Bitirme_Model.ViewModels;
using FluentValidation;

namespace Bitirme_Projesi.Validators
{
    public class ShoppingListValidator : AbstractValidator<ShoppingListViewModel>
    {
        public ShoppingListValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Alışveriş listesinin adı boş olamaz")
                .MaximumLength(50).WithMessage("Alışveriş listesinin adı en fazla 50 karakter olmalıdır.");
        }
    }
}
