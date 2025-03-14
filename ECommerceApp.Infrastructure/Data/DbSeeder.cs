namespace ECommerceApp.Infrastructure.Data
{
    public static class DbSeeder
    {
        public async static Task SeedData(AppDbContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                var password = "admin123";
                var passwordHash = AuthService.HashPassword(password);
                var adminUser = new User
                {
                    Id = Guid.NewGuid(),
                    FullName = "Admin",
                    Email = "admin@admin.com",
                    PasswordHash = passwordHash
                };

                await context.Users.AddAsync(adminUser);
            }

            if (!await context.Products.AnyAsync())
            {
                var product1 = new Product
                {
                    Price = 100,
                    Quantity = 10,
                };

                var product2 = new Product
                {
                    Price = 200,
                    Quantity = 20,
                };

                await context.Products.AddRangeAsync(product1, product2);

                var translation1 = new ProductTranslation
                {
                    ProductId = product1.Id,
                    LanguageCode = "en",
                    Name = "Mouse",
                    Description = "Logitech Mouse G102"
                };

                var translation2 = new ProductTranslation
                {
                    ProductId = product1.Id,
                    LanguageCode = "fr",
                    Name = "Souris",
                    Description = "Logitech Souris G102"
                };

                var translation3 = new ProductTranslation
                {
                    ProductId = product2.Id,
                    LanguageCode = "en",
                    Name = "Keyboard",
                    Description = "Redragon Keyboard K552"
                };

                await context.ProductTranslations.AddRangeAsync(translation1, translation2, translation3);
            }

            await context.SaveChangesAsync();
        }
    }
}
