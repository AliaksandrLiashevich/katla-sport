using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.HiveSectionManagement
{
    public interface IHiveSectionProductsService
    {
        /// <summary>
        /// Gets a list of hive section categories.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns>A <see cref="Task{List{HiveSectionListItem}}"/>.</returns>
        Task<List<ProductCategoryListItem>> GetHiveSectionCategoriesAsync(int hiveSectionId);

        /// <summary>
        /// Gets a list of hive section category products.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <param name="categoryId">A category identifier.</param>
        /// <returns>A <see cref="Task{List{ProductListItem}}"/>.</returns>
        Task<List<ProductListItem>> GetHiveSectionCategoryProductsAsync(int hiveSectionId, int categoryId);
    }
}
