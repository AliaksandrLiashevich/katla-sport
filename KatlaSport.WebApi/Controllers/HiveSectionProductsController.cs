using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.HiveSectionManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/product")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class HiveSectionProductsController : ApiController
    {
        private readonly IHiveSectionProductsService _hiveSectionProductsService;

        public HiveSectionProductsController(IHiveSectionProductsService hiveSectionCategoryService)
        {
            _hiveSectionProductsService = hiveSectionCategoryService ?? throw new ArgumentNullException(nameof(hiveSectionCategoryService));
        }

        [HttpPut]
        [Route("{storeItemId:int:min(1)}/approvedStatus/{approvedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed hive.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetApprovedStatusAsync([FromUri] int storeItemId, [FromUri] bool approvedStatus)
        {
            await _hiveSectionProductsService.SetApprovedStatusAsync(storeItemId, approvedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("{hiveId:int:min(1)}/deletedStatus/{deletedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed hive.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetDeletedStatusAsync([FromUri] int hiveId, [FromUri] bool deletedStatus)
        {
            await _hiveSectionProductsService.SetDeletedStatusAsync(hiveId, deletedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}