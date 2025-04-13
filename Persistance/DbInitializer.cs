using System.Text.Json;

namespace Persistance
{
    public class DbInitializer(StoreDbContext _context)
        : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            try
            {
                ////dev
                //if ((await _context.Database.GetPendingMigrationsAsync()).Any())
                //    await _context.Database.MigrateAsync();

                if (!await _context.Set<ProductBrand>().AnyAsync())
                {
                    var data = await ReadFileAsync("Data/Seeding/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(data);

                    if (brands is not null && brands.Any())
                    {
                        await _context.Set<ProductBrand>().AddRangeAsync(brands);
                        await _context.SaveChangesAsync();
                    }
                }

                if (!await _context.Set<ProductType>().AnyAsync())
                {
                    var data = await ReadFileAsync("Data/Seeding/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(data);
                    if (types is not null && types.Any())
                    {
                        await _context.Set<ProductType>().AddRangeAsync(types);
                        await _context.SaveChangesAsync();
                    }
                }

                if (!await _context.Products.AnyAsync())
                {
                    //C: \Users\M4_ElShenawy\source\repos\E - Commerce\Persistance\Data\Seeding\products.json
                    var productsData = await File.ReadAllTextAsync(@"..\Persistance\Data\Seeding\products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products != null && products.Any())
                    {
                        await _context.AddRangeAsync(products);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Seeding :");
                Console.WriteLine(ex.ToString());
            }



        }
        private async Task<string> ReadFileAsync(string relativePath)
        {
            var basePath = AppContext.BaseDirectory;
            Console.WriteLine(basePath);
            var fullPath = Path.Combine(basePath, relativePath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Seed file not found: {fullPath}");

            return await File.ReadAllTextAsync(fullPath);
        }

    }
}
//C: \Users\M4_ElShenawy\source\repos\E-Commerce\Persistance\Data\Seeding\brands.json
