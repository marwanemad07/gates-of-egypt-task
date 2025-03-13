
using ECommerceApp.Application.Interfaces;

namespace ECommerceApp.Application.Services.Implementations
{
    public class ProductTranslationService : IProductTranslationService
    {
        private readonly IProductTranslationRepository _productTranslationRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        // This should be in a configuration file or database but for simplicity we will use a HashSet
        private static readonly HashSet<string> ValidLanguageCodes = new()
        {
            "en", "fr", "es", "de", "it", "ar", "zh", "ru", "ja"
        };

        public ProductTranslationService(IProductTranslationRepository productTranslationRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productTranslationRepository = productTranslationRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<RestDto<ProductTranslationDto>> AddProductTranslationAsync(Guid productId, NewProductTranslationDto dto)
        {
            if(!ValidLanguageCodes.Contains(dto.LanguageCode))
            {
                return new RestDto<ProductTranslationDto>(400, message: "Invalid language code.");
            }

            // Check if the product exists or not
            var product = await _productRepository.GetByIdAsync(productId);
            if(product == null)
            {
                return new RestDto<ProductTranslationDto>(404, message: "Product doesn't exist.");
            }

            // Check if the translation already exists
            var productTranslationExists = await _productTranslationRepository.GetTranslationAsync(productId, dto.LanguageCode);
            if (productTranslationExists != null)
            {
                return new RestDto<ProductTranslationDto>(400, message: "Translation already exists.");
            }

            var productTranslation = _mapper.Map<ProductTranslation>(dto);
            productTranslation.ProductId = productId;

            await _productTranslationRepository.AddAsync(productTranslation);

            productTranslation = await _productTranslationRepository.GetTranslationAsync(productId, dto.LanguageCode);

            if (productTranslation == null)
            {
                return new RestDto<ProductTranslationDto>(500);
            }

            var productTranslationDto = _mapper.Map<ProductTranslationDto>(productTranslation);
            return new RestDto<ProductTranslationDto>(201, productTranslationDto);
        }

        public async Task<RestDto<ProductTranslationDto>> GetProductTranslationAsync(Guid productId, string languageCode)
        {
            var productTranslation = await _productTranslationRepository.GetTranslationAsync(productId, languageCode);

            if (productTranslation == null)
            {
                return new RestDto<ProductTranslationDto>(404);
            }

            var productTranslationDto = _mapper.Map<ProductTranslationDto>(productTranslation);
            return new RestDto<ProductTranslationDto>(200, productTranslationDto);
        }
    }
}
