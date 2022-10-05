using Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext Context,ILoggerFactory loggerFactory)
        {
            try
            {
                if(!Context.ProductBrands.Any())
                {
                    var brandsData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands)
                    {
                        Context.ProductBrands.Add(item);
                    }
                    await Context.SaveChangesAsync();
                }
                if (!Context.ProductTypes.Any())
                {
                    var typesData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        Context.ProductTypes.Add(item);
                    }

                    await Context.SaveChangesAsync();
                }

                if (!Context.Products.Any())
                {
                    var productsData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        Context.Products.Add(item);
                    }

                    await Context.SaveChangesAsync();
                }

                //if (!context.DeliveryMethods.Any())
                //{
                //    var dmData =
                //        File.ReadAllText(path + @"/Data/SeedData/delivery.json");

                //    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                //    foreach (var item in methods)
                //    {
                //        context.DeliveryMethods.Add(item);
                //    }

                //    await context.SaveChangesAsync();
                //}
            
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
