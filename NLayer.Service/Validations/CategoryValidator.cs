using FluentValidation;
using Nlayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class CategoryValidator:AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.categoryName).NotNull().WithMessage("Kategori adı boş geçilemez.").NotEmpty().WithMessage("Kategori adı boş geçilemez.");
        }
    }
}
