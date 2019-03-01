namespace KatlaSport.Services.ProductManagement
{
    public class HiveSectionProduct : ProductCategoryProductListItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether a product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product query is approved by forwarder
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a quantity of items of certain product in the location.
        /// </summary>
        public int Quantity { get; set; }
    }
}
