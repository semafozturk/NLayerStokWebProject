using FluentValidation;
using Nlayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class SaleValidator:AbstractValidator<SaleDto>
    {
        public SaleValidator()
        {
            RuleFor(x => x.salesQuantity).InclusiveBetween(1, int.MaxValue).WithMessage("Satış adedi 0'dan büyük olmalıdır.");
            RuleFor(x => x.saleDate).Must(mustBeDate).WithMessage("Satış tarihinin girilmesi zorunludur.");
            RuleFor(x => x.productId).InclusiveBetween(1, int.MaxValue).WithMessage("Satılacak ürün seçilmelidir.");
        }
        private bool mustBeDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
