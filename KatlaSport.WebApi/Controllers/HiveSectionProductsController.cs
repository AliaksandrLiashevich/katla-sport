using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.HiveSectionManagement;
using KatlaSport.Services.ProductManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/section")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class HiveSectionProductsController : ApiController
    {
        private readonly IHiveSectionProductsService _hiveSectionCategoryService;

        public HiveSectionProductsController(IHiveSectionProductsService hiveSectionCategoryService)
        {
            _hiveSectionCategoryService = hiveSectionCategoryService ?? throw new ArgumentNullException(nameof(hiveSectionCategoryService));
        }

        [HttpGet]
        [Route("{hiveSectionId:int:min(1)}/categories")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive section categories.", Type = typeof(ProductCategoryListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionCategories([FromUri] int hiveSectionId)
        {
            var categories = await _hiveSectionCategoryService.GetHiveSectionCategoriesAsync(hiveSectionId);
            return Ok(categories);
        }

        [HttpGet]
        [Route("{hiveSectionId:int:min(1)}/category/{categoryId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive section products.", Type = typeof(ProductListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionCategoryProducts([FromUri] int hiveSectionId, [FromUri] int categoryId)
        {
            var categories = await _hiveSectionCategoryService.GetHiveSectionCategoryProductsAsync(hiveSectionId, categoryId);
            return Ok(categories);
        }
    }
}