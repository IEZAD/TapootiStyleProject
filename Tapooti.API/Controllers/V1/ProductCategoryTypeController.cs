using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using _0_Framework.Apllication.Controllers;
using ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType;

namespace Tapooti.API.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductCategoryTypeController : TapootiApiController
    {
        private readonly IProductCategoryTypeApplication _productCategoryTypeApplication;

        public ProductCategoryTypeController(IProductCategoryTypeApplication productCategoryTypeApplication)
        {
            _productCategoryTypeApplication = productCategoryTypeApplication;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetMenu")]
        public async Task<IActionResult> ExecuteAsync()
        {
            var response = await _productCategoryTypeApplication.ExecuteAsync();
            return TapootiObjectResult(response);
        }

        [HttpGet]
        [Route("FindProductCategoryTypeById")]
        public async Task<IActionResult> FindProductCategoryTypeById([FromQuery] Guid id)
        {
            var response = await _productCategoryTypeApplication.GetDetailsAsync(id);
            return TapootiObjectResult(response);
        }

        [HttpGet]
        [Route("GetProductCategoryTypes")]
        public async Task<IActionResult> GetProductCategoryTypes([FromQuery] ProductCategoryTypeListRequest request)
        {
            var response = await _productCategoryTypeApplication.GetProductCategoryTypesAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("SearchProductCategoryType")]
        public async Task<IActionResult> SearchAsync(ProductCategoryTypeSearchModel request)
        {
            var response = await _productCategoryTypeApplication.SearchAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("CreateProductCategoryType")]
        public async Task<IActionResult> CreateAsync(CreateProductCategoryType request)
        {
            var response = await _productCategoryTypeApplication.CreateAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPut]
        [Route("UpdateProductCategoryType")]
        public async Task<IActionResult> UpdateAsync(UpdateProductCategoryType request)
        {
            var response = await _productCategoryTypeApplication.UpdateAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpDelete]
        [Route("DeleteProductCategoryTypeById")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            var response = await _productCategoryTypeApplication.DeleteAsync(id);
            return TapootiObjectResult(response);
        }
    }
}