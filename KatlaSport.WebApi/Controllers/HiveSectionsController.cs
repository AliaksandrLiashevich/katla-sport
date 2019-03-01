using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.HiveManagement;
using KatlaSport.Services.ProductManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sections")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class HiveSectionsController : ApiController
    {
        private readonly IHiveSectionService _hiveSectionService;

        public HiveSectionsController(IHiveSectionService hiveSectionService)
        {
            _hiveSectionService = hiveSectionService ?? throw new ArgumentNullException(nameof(hiveSectionService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of hive sections.", Type = typeof(HiveSectionListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionsAsync()
        {
            var hives = await _hiveSectionService.GetHiveSectionsAsync();
            return Ok(hives);
        }

        [HttpGet]
        [Route("{hiveSectionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive section.", Type = typeof(HiveSection))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionAsync(int hiveSectionId)
        {
            var hive = await _hiveSectionService.GetHiveSectionAsync(hiveSectionId);
            return Ok(hive);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new hive section.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddHiveSection([FromBody] UpdateHiveSectionRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hiveSection = await _hiveSectionService.CreateHiveSectionAsync(createRequest);
            var location = string.Format("/api/sections/{0}", hiveSection.Id);
            return Created<HiveSection>(location, hiveSection);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed hive section.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateHiveSection([FromUri] int id, [FromBody] UpdateHiveSectionRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hiveSectionService.UpdateHiveSectionAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed hive section.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteHiveSection([FromUri] int id)
        {
            await _hiveSectionService.DeleteHiveSectionAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("{hiveSectionId:int:min(1)}/status/{deletedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed hive section.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetStatus([FromUri] int hiveSectionId, [FromUri] bool deletedStatus)
        {
            await _hiveSectionService.SetStatusAsync(hiveSectionId, deletedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpGet]
        [Route("{hiveSectionId:int:min(1)}/categories")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive section categories.", Type = typeof(ProductCategoryListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionCategories([FromUri] int hiveSectionId)
        {
            var categories = await _hiveSectionService.GetHiveSectionCategoriesAsync(hiveSectionId);
            return Ok(categories);
        }

        [HttpGet]
        [Route("{hiveSectionId:int:min(1)}/category/{categoryId:int:min(1)}/products")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive section products.", Type = typeof(HiveSectionProduct))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionCategoryProducts([FromUri] int hiveSectionId, [FromUri] int categoryId)
        {
            var categories = await _hiveSectionService.GetHiveSectionCategoryProductsAsync(hiveSectionId, categoryId);
            return Ok(categories);
        }

        [HttpGet]
        [Route("{hiveSectionId:int:min(1)}/category/{categoryId:int:min(1)}/avaliableProducts")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns avaliable hive section category products.", Type = typeof(ProductCategoryProductListItem))]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Category doesn't contain avaliable products")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetAvaliableHiveSectionCategoryProducts([FromUri] int hiveSectionId, [FromUri] int categoryId)
        {
            var categories = await _hiveSectionService.GetHiveSectionCategoryAvailableProductsAsync(hiveSectionId, categoryId);
            return Ok(categories);
        }
    }
}
