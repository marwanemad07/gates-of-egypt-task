namespace ECommerceApp.Application.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        public Task<Cart?> GetCartByUserIdAsync(Guid userId);
    }
}
