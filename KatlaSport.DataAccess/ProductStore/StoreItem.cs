using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.DataAccess.ProductStore
{
    /// <summary>
    /// Represents a product store item.
    /// </summary>
    public class StoreItem
    {
        /// <summary>
        /// Gets or sets a product store item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a product.
        /// </summary>
        public virtual CatalogueProduct Product { get; set; }

        /// <summary>
        /// Gets or sets a location ID.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a location.
        /// </summary>
        public virtual StoreHiveSection HiveSection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product query is approved by forwarder
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product is deleted from section.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a quantity of items of certain product in the location.
        /// </summary>
        public int Quantity { get; set; }
    }
}
