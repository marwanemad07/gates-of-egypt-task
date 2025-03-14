namespace ECommerceApp.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration cfg)
        {
            string connectionString = cfg.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.Configure<JwtSettings>(cfg.GetSection("JwtSettings"));

            services.AddSingleton<JwtTokenGenerator>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTranslationRepository, ProductTranslationRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemsRepository, CartItemsRepository>();

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
