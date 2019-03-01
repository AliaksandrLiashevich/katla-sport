using System.Linq;
using System.Threading.Tasks;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.Services.ProductManagement;

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
        public async Task AddHiveSectionCategoryProductAsync(UpdateHiveSectionCategoryProduct createRequest)
        {
            StoreItem newItem = new StoreItem();

            newItem.Id = _context.Items.Max(i => i.Id) + 1;
            newItem.ProductId = createRequest.Id;
            newItem.Quantity = createRequest.Quantity;
            newItem.HiveSectionId = createRequest.HiveSectionId;

            _context.Items.Add(newItem);

            await _context.SaveChangesAsync();
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

        /// <inheritdoc/>
        public async Task DeleteHiveSectionCategoryProductAsync(int storeItemId)
        {
            var dbStoreItems = await _context.Items.Where(s => s.Id == storeItemId).ToArrayAsync();

            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];

            if (dbStoreItem.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Items.Remove(dbStoreItem);

            await _context.SaveChangesAsync();
        }
    }
}
