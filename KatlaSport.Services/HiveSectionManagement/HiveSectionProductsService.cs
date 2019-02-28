using System.Linq;
using System.Threading.Tasks;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.Services.HiveSectionManagement
{
    public class HiveSectionProductsService : IHiveSectionProductsService
    {
        private readonly IProductStoreContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HiveSectionProductsService"/> class.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreContext"/>.</param>
        public HiveSectionProductsService(IProductStoreContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task SetApprovedStatusAsync(int storeItemId, bool approvedStatus)
        {
            var dbStoreItems = await _context.Items.Where(s => s.Id == storeItemId).ToArrayAsync();

            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];

            dbStoreItem.IsApproved = approvedStatus;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task SetDeletedStatusAsync(int storeItemId, bool deletedStatus)
        {
            var dbStoreItems = await _context.Items.Where(s => s.Id == storeItemId).ToArrayAsync();

            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];

            dbStoreItem.IsDeleted = deletedStatus;

            await _context.SaveChangesAsync();
        }
    }
}
