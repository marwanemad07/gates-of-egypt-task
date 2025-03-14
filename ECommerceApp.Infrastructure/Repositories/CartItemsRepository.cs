namespace ECommerceApp.Infrastructure.Repositories
{
    public class CartItemsRepository : GenericRepository<CartItem>, ICartItemsRepository
    {
        public CartItemsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
