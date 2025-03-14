
namespace ECommerceApp.Application.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemsRepository _cartItemsRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository,
            ICartItemsRepository cartItemsRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _cartItemsRepository = cartItemsRepository;
            _mapper = mapper;
        }

        public async Task<RestDto<CartDto>> AddProductToCartAsync(Guid userId, Guid productId, int quantity)
        {
            var cart = await GetOrCreateCartAsync(userId);

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity,
                };
                await _cartItemsRepository.AddAsync(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
                await _cartRepository.UpdateAsync(cart);
            }

            await _cartRepository.UpdateAsync(cart);

            var restDto = await GetCartByUserIdAsync(userId);
            return restDto;
        }

        public async Task<RestDto<CartDto>> GetCartByUserIdAsync(Guid userId)
        {
            var cart = await GetOrCreateCartAsync(userId);

            var cartDto = _mapper.Map<CartDto>(cart);
            return new RestDto<CartDto>(200, cartDto);
        }

        public async Task<RestDto<bool>> RemoveProductFromCartAsync(Guid userId, Guid productId)
        {
            var cart = await GetOrCreateCartAsync(userId);

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                return new RestDto<bool>(404, false);
            }

            cart.CartItems.Remove(cartItem);

            await _cartRepository.UpdateAsync(cart);

            return new RestDto<bool>(200, true);
        }

        private async Task<Cart> GetOrCreateCartAsync(Guid userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                };
                await _cartRepository.AddAsync(cart);
            }

            return cart;
        }
    }
}
