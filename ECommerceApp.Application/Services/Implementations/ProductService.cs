using ECommerceApp.Application.Interfaces;

namespace ECommerceApp.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper) 
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<RestDto<ProductDto>> AddProductAsync(NewProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(product);
            var restDto = await GetProductByIdAsync(product.Id);
            
            if(restDto.StatusCode == 404)
            {
                return new RestDto<ProductDto>(500, restDto);
            }

            return new RestDto<ProductDto>(201, restDto);
        }

        public async Task<RestDto<bool>> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product != null) {
                await _productRepository.DeleteAsync(product);
                return new RestDto<bool>(200, true);
            }

            return new RestDto<bool>(404, false);
        }

        public async Task<RestDto<ProductDto>> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return new RestDto<ProductDto>(404);
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return new RestDto<ProductDto>(200, productDto);
        }

        public async Task<RestDto<IReadOnlyList<ProductDto>>> GetProductsAsync()
        {
            // TODO: we should use pagination here (we may add specification pattern to make it maintainable)
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            return new RestDto<IReadOnlyList<ProductDto>>(200, productDtos);
        }

        public async Task<RestDto<ProductDto>> UpdateProductAsync(Guid id, NewProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return new RestDto<ProductDto>(404);
            }

            product.Price = dto.Price;
            // This may be changed, so that we add the new quantity to the existing quantity
            product.Quantity = dto.Quantity;

            await _productRepository.UpdateAsync(product);
            var restDto = await GetProductByIdAsync(id);

            return restDto;
        }
    }
}
