using FluentValidation;
using Nlayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class ProductValidator:AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.productName).NotEmpty().WithMessage("İsim alanı zorunludur.").NotNull().WithMessage("İsim alanı zorunludur.");
            RuleFor(x => x.purchasePrice).InclusiveBetween(1, int.MaxValue).WithMessage("Alış fiyatı alanı 0'dan büyük olmalıdır.");
            RuleFor(x=>x.salePrice).InclusiveBetween(1, int.MaxValue).WithMessage("Satış fiyatı alanı 0'dan büyük olmalıdır.");
            RuleFor(x=>x.stock).InclusiveBetween(1, int.MaxValue).WithMessage("Stok alanı 0'dan büyük olmalıdır.");

        }
    }
}
