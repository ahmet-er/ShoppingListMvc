using Bitirme_Model.ViewModels;
using FluentValidation;

namespace Bitirme_Projesi.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olmalıdır.");
        }
    }
}
