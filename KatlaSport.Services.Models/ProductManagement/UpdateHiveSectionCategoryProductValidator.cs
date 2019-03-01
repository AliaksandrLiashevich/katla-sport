using FluentValidation;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateHiveSectionCategoryProduct"/>.
    /// </summary>
    public class UpdateHiveSectionCategoryProductValidator: AbstractValidator<UpdateHiveSectionCategoryProduct>
    {
        public UpdateHiveSectionCategoryProductValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Code).Length(5);
        }
    }
}
