namespace ECommerceApp.Application.Services.Interfaces
{
    public interface IProductService
    {
        public Task<RestDto<ProductDto>> AddProductAsync(NewProductDto dto);
        public Task<RestDto<IReadOnlyList<ProductDto>>> GetProductsAsync();
        public Task<RestDto<ProductDto>> GetProductByIdAsync(Guid id);
        public Task<RestDto<ProductDto>> UpdateProductAsync(Guid id, NewProductDto dto);
        public Task<RestDto<bool>> DeleteProductAsync(Guid id);
    }
}
