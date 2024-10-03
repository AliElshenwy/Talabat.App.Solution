using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entitise;

namespace Talabat.Repository
{
    public static  class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext _dbcontext )
        {
            var brandData = File.ReadAllText("../Talabat.Repository/DataSeeding/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData); // Converse Date In json ot Any value type

            if (brands.Count() > 0)
            {
                brands = brands.Select(b => new ProductBrand()
                {               // تحيد الاسم  بدون ID 
                    Name = b.Name,
                }).ToList();

                if (_dbcontext.productBrands.Count() == 0)
                {
                    foreach (var brand in brands)
                    {
                        _dbcontext.Set<ProductBrand>().Add(brand);
                    }
                    await _dbcontext.SaveChangesAsync();
                }
            }
           
            var CategoryData = File.ReadAllText("../Talabat.Repository/DataSeeding/categories.json");
            var Categorise = JsonSerializer.Deserialize<List<ProductCategory>>(CategoryData); // Converse Date In json ot Any value type

            if (Categorise.Count() > 0)
            {
                Categorise = Categorise.Select(b => new ProductCategory()
                {               // تحيد الاسم  بدون ID 
                    Name = b.Name,
                }).ToList();

                if (_dbcontext.productCategories.Count() == 0)
                {
                    foreach (var category in Categorise)
                    {
                        _dbcontext.Set<ProductCategory>().Add(category);
                    }
                    await _dbcontext.SaveChangesAsync();
                }
            }
            var ProudctsData = File.ReadAllText("../Talabat.Repository/DataSeeding/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(ProudctsData); // Converse Date In json ot Any value type

            if (products.Count() > 0)
            {

                //products = products.Select(b => new Product()
                //{               // تحيد الاسم  بدون ID 
                //    Name = b.Name,
                //}).ToList();

                if (_dbcontext.products.Count() == 0)
                {
                    foreach (var product in products)
                    {
                        _dbcontext.Set<Product>().Add(product);
                    }
                    await _dbcontext.SaveChangesAsync();
                }
            }
        }

        
    }
}
