using TestAsp.Data;

namespace TestAsp.Servise
{
    public static class DbSeeder
    {
        public static void Seeder(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<EFContext>();
                if (!_context.Products.Any())
                {
                    _context.Products.Add(new Data.Entities.AppProduct
                    {
                        Name = "Сало",
                        Description = "Сало соленое"
                        
                    });
                    _context.Products.Add(new Data.Entities.AppProduct
                    {
                        Name = "Сало",
                        Description = "Сало перченое"
                        
                    });
                    _context.Products.Add(new Data.Entities.AppProduct
                    {
                        Name = "Сало",
                        Description = "Сало с паприкой"
                        
                    });
                    _context.Products.Add(new Data.Entities.AppProduct
                    {
                        Name = "Хлеб",
                        Description = "Хлеб бародинский"
                        
                    });
                    _context.Products.Add(new Data.Entities.AppProduct
                    {
                        Name = "Хлеб",
                        Description = "Хлеб с высевками"
                    
                    });

                    _context.SaveChanges();
                }
            }
        }
    }
}
