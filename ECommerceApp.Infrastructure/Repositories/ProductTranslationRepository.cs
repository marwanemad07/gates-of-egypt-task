using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class ProductTranslationRepository : GenericRepository<ProductTranslation>, IProductTranslationRepository
    {
        public ProductTranslationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProductTranslation?> GetTranslationAsync(Guid productId, string languageCode)
        {
            var translation = await _context.ProductTranslations
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageCode == languageCode);
            return translation;
        }
    }
}
