namespace ECommerceApp.Application.Interfaces
{
    public interface IProductTranslationRepository : IGenericRepository<ProductTranslation>
    {
        Task<ProductTranslation?> GetTranslationAsync(Guid productId, string languageCode);
    }
}
