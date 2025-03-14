using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("{userId}/items")]
        [Authorize]
        public async Task<IActionResult> AddProductToCartAsync(Guid userId, AddToCartDto dto)
        {
            if (!IsAuthorized(userId))
            {
                var badRequestDto = new RestDto<bool>(400);
                return StatusCode(badRequestDto.StatusCode, badRequestDto);
            }
            var result = await _cartService.AddProductToCartAsync(userId, dto.ProductId, dto.Quantity);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetCartByUserIdAsync(Guid userId)
        {
            if (!IsAuthorized(userId))
            {
                var badRequestDto = new RestDto<bool>(400);
                return StatusCode(badRequestDto.StatusCode, badRequestDto);
            }
            var result = await _cartService.GetCartByUserIdAsync(userId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{userId}/items/{productId}")]
        [Authorize]
        public async Task<IActionResult> RemoveProductFromCartAsync(Guid userId, Guid productId)
        {
            if (!IsAuthorized(userId))
            {
                var badRequestDto = new RestDto<bool>(400);
                return StatusCode(badRequestDto.StatusCode, badRequestDto);
            }
            var result = await _cartService.RemoveProductFromCartAsync(userId, productId);
            return StatusCode(result.StatusCode, result);
        }

        private bool IsAuthorized(Guid userId)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId.ToString() == id;
        }
    }
}
