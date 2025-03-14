namespace ECommerceApp.Application.Services.Interfaces
{
    public interface ICartService
    {
        public Task<RestDto<CartDto>> GetCartByUserIdAsync(Guid userId);
        public Task<RestDto<CartDto>> AddProductToCartAsync(Guid userId, Guid productId, int quantity);
        public Task<RestDto<bool>> RemoveProductFromCartAsync(Guid userId, Guid productId);
    }
}
