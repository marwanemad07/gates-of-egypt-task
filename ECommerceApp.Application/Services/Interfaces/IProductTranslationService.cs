namespace ECommerceApp.Application.Services.Interfaces
{
    public interface IProductTranslationService
    {
        public Task<RestDto<ProductTranslationDto>> AddProductTranslationAsync(Guid productId, NewProductTranslationDto dto);
        public Task<RestDto<ProductTranslationDto>> GetProductTranslationAsync(Guid productId, string languageCode);
    }
}
