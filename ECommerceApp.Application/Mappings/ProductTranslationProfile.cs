namespace ECommerceApp.Application.Mappings
{
    public class ProductTranslationProfile : Profile
    {
        public ProductTranslationProfile()
        {
            CreateMap<ProductTranslation, ProductTranslationDto>();

            CreateMap<NewProductTranslationDto, ProductTranslation>();
        }
    }
}
