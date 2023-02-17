using FluentValidation;
using Nlayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class PurchaseValidator:AbstractValidator<PurchaseDto>
    {
        public PurchaseValidator()
        {
            RuleFor(x => x.purchasesQuantity).InclusiveBetween(1, int.MaxValue).WithMessage("Alış adedi 0'dan büyük olmalıdır.");
            RuleFor(x => x.purchaseDate).Must(mustBeDate).WithMessage("Alış tarihinin girilm+esi zorunludur.");
            RuleFor(x => x.productId).InclusiveBetween(1, int.MaxValue).WithMessage("Satılacak ürün seçilmelidir.");
        }
        private bool mustBeDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
