using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/products/{productId}")]
    [ApiController]
    public class ProductTranslationsController : ControllerBase
    {
        private readonly IProductTranslationService _productTranslationService;

        public ProductTranslationsController(IProductTranslationService productTranslationService)
        {
            _productTranslationService = productTranslationService;
        }

        [HttpPost("translations")]
        public async Task<IActionResult> AddProductTranslationAsync(Guid productId, NewProductTranslationDto dto)
        {
            var result = await _productTranslationService.AddProductTranslationAsync(productId, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{language}")]
        public async Task<IActionResult> GetProductTranslationAsync(Guid productId, string language)
        {
            var result = await _productTranslationService.GetProductTranslationAsync(productId, language);
            return StatusCode(result.StatusCode, result);
        }
    }
}
