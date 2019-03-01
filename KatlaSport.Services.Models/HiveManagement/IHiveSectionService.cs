using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive section service.
    /// </summary>
    public interface IHiveSectionService
    {
        /// <summary>
        /// Gets a list of hive sections.
        /// </summary>
        /// <returns>A <see cref="Task{List{HiveSectionListItem}}"/>.</returns>
        Task<List<HiveSectionListItem>> GetHiveSectionsAsync();

        /// <summary>
        /// Gets a hive section.
        /// </summary>
        /// <param name="id">A hive section identifier.</param>
        /// <returns>A <see cref="Task{HiveSection}"/>.</returns>
        Task<HiveSection> GetHiveSectionAsync(int id);

        /// <summary>
        /// Gets a list of hive sections for specified hive.
        /// </summary>
        /// <param name="hiveId">A hive identifier.</param>
        /// <returns>A <see cref="Task{List{HiveSectionListItem}}"/>.</returns>
        Task<List<HiveSectionListItem>> GetHiveSectionsAsync(int hiveId);

        /// <summary>
        /// Creates a new hive section.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateHiveSectionRequest"/>.</param>
        /// <returns>A <see cref="Task{HiveSection}"/>.</returns>
        Task<HiveSection> CreateHiveSectionAsync(UpdateHiveSectionRequest createRequest);

        /// <summary>
        /// Updates a hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateHiveSectionRequest"/>.</param>
        /// <returns>A <see cref="Task{HiveSection}"/></returns>
        Task<HiveSection> UpdateHiveSectionAsync(int hiveSectionId, UpdateHiveSectionRequest updateRequest);

        /// <summary>
        /// Deletes a hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns>A <see cref="Task"/></returns>
        Task DeleteHiveSectionAsync(int hiveSectionId);

        /// <summary>
        /// Sets deleted status for a hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetStatusAsync(int hiveSectionId, bool deletedStatus);

        /// <summary>
        /// Gets a list of hive section categories.
        /// </summary>
        /// <param name="hiveSectionId">A hive identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task<List<ProductCategoryListItem>> GetHiveSectionCategoriesAsync(int hiveSectionId);

        /// <summary>
        /// Gets a list of hive section categoru products.
        /// </summary>
        /// <param name="hiveSectionId">A hive identifier.</param>
        /// <param name="categoryId">A category identifier</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task<List<HiveSectionProduct>> GetHiveSectionCategoryProductsAsync(int hiveSectionId, int categoryId);

        /// <summary>
        /// Gets a list of avaliable hive section categoru products.
        /// </summary>
        /// <param name="hiveSectionId">A hive identifier.</param>
        /// <param name="categoryId">A category identifier</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task<List<ProductCategoryProductListItem>> GetHiveSectionCategoryAvailableProductsAsync(int hiveSectionId, int categoryId);
    }
}
