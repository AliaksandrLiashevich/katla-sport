using FluentValidation.Attributes;

namespace KatlaSport.Services.ProductManagement
{
    [Validator(typeof(UpdateHiveSectionCategoryProductValidator))]
    public class UpdateHiveSectionCategoryProduct
    {
        /// <summary>
        /// Gets or sets a product identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a hive section identifier.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a product code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a product quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}
