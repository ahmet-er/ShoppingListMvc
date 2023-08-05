using Bitirme_Model.Entities;
using Bitirme_Model.ViewModels;
using FluentValidation;

namespace Bitirme_Projesi.Validators
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olmalıdır.");

            //RuleFor(p => p.Price)
            //    .ScalePrecision(2, 18).WithMessage("Fiyat alanı en fazla 18 basamaklı ve 2 ondalık basamağa sahip olmalıdır.");

            //        //RuleFor(p => p.ImageFilePath)
            //        //    .NotEmpty().WithMessage("Ürün resmi boş bırakılamaz.")
            //        //    .MaximumLength(200).WithMessage("Resim dosyasının yolu en fazla 200 karakter olmalıdır.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Lütfen bir kategori seçiniz.")
                .NotEqual(0).WithMessage("Lütfen bir kategori seçiniz.");

            //        //RuleFor(p => p.Categories)
            //        //    .Must(c => c != null && c.Any()).WithMessage("En az bir kategori seçeneği olmalıdır.");
        }
    }
}
