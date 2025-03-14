
namespace ECommerceApp.Infrastructure.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<Cart?> GetCartByUserIdAsync(Guid userId)
        {
            var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .ThenInclude(p => p.Translations)
            .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive);

            return cart;
        }
    }
}
