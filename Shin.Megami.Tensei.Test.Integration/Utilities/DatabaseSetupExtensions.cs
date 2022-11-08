using Shin.Megami.Tensei.Data.Context;
using Shin.Megami.Tensei.Data.SeedData;

namespace Shin.Megami.Tensei.Test.Integration.Utilities
{
    public static class DatabaseSetupExtensions
    {
        public static void InitializeDatabaseForTests(this HealthCtx context)
        {
            var productFactory = new ProductFactory();
            var products = productFactory.GenerateRandomProducts(250);

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static void ReinitializeDatabaseForTests(this HealthCtx context)
        {
            context.Products.RemoveRange(context.Products);
            context.InitializeDatabaseForTests();
        }
    }
}
