using System.Threading.Tasks;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.HiveSectionManagement
{
    public interface IHiveSectionProductsService
    {
        /// <summary>
        /// Set approved status with the following values: true or false
        /// </summary>
        /// <param name="storeItemId">A store item identifier</param>
        /// <param name="approvedStatus">bool value</param>
        /// <returns>A <see cref="Task"/></returns>
        Task SetApprovedStatusAsync(int storeItemId, bool approvedStatus);

        /// <summary>
        /// Set deleted status with the following values: true or false
        /// </summary>
        /// <param name="storeItemId">A store item identifier</param>
        /// <param name="deletedStatus">bool value</param>
        /// <returns>A <see cref="Task"/></returns>
        Task SetDeletedStatusAsync(int storeItemId, bool deletedStatus);

        /// <summary>
        /// Add new product to hive section category
        /// </summary>
        /// <param name="createRequest">Product info</param>
        /// <returns>A <see cref="Task"/></returns>>
        Task AddHiveSectionCategoryProductAsync(UpdateHiveSectionCategoryProduct createRequest);
    }
}
