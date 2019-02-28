using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.DataAccess.ProductStoreHive;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.HiveSectionManagement
{
    public class HiveSectionProductsService : IHiveSectionProductsService
    {
        private readonly IProductStoreHiveContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="HiveSectionProductsService"/> class with specified <see cref="IProductStoreContext"/> and <see cref="IUserContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreHiveContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public HiveSectionProductsService(IProductStoreHiveContext context, IUserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        /// <inheritdoc/>
        public async Task<List<ProductCategoryListItem>> GetHiveSectionCategoriesAsync(int hiveSectionId)
        {
            var dbHiveSections = await _context.Sections.Where(s => s.Id == hiveSectionId).ToArrayAsync();

            if (dbHiveSections.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbHiveSectionCategories = dbHiveSections[0].Categories.ToList();
            var hiveSectionCategories = dbHiveSectionCategories.Select(hsc => Mapper.Map<ProductCategoryListItem>(hsc.Category)).ToList();

            return hiveSectionCategories;
        }

        /// <inheritdoc/>
        public async Task<List<ProductListItem>> GetHiveSectionCategoryProductsAsync(int hiveSectionId, int categoryId)
        {
            var dbHiveSections = await _context.Sections.Where(s => s.Id == hiveSectionId).ToArrayAsync();

            if (dbHiveSections.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbCategories = await _context.Categories.Where(c => c.ProductCategoryId == categoryId).ToArrayAsync();

            if (dbCategories.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var hiveSectionItems = dbHiveSections[0].Items.Where(i => i.Product.CategoryId == categoryId && i.HiveSectionId == hiveSectionId);

            return hiveSectionItems.Select(i => Mapper.Map<ProductListItem>(i.Product)).ToList();
        }
    }
}
