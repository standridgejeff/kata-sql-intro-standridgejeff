using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
#if DEBUG
            .AddJsonFile("appsettings.Debug.json")
#else
            .AddJsonFile("appsettings.Release.json")
#endif
            .Build();

            var connectionString = configuration.GetConnectionString("Default Connection");

            var repo = new DapperProductRepository(connectionString);

            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name);
            }
            
            foreach (var prod in repo.GetProductsWithReviews())
            {
                Console.WriteLine("Product Name:" + prod.Name + "Product Id:" + prod.Id + "Product Review:" + prod.Comments);
            }
            
            foreach (var prod in repo.GetProductsAndReviews())
            {
                Console.WriteLine("Product Name:" + prod.Name + "Product Id:" + prod.Id + "Product Review:" + prod.Comments);
            }

            repo.DeleteProduct(123);

            var newProduct = new Product {Name = "Whatever"};
            repo.InsertProduct(newProduct);

            var updatedProduct = new Product {Name = "Whatevernow"};
            repo.UpdateProduct(updatedProduct);

            Console.ReadLine();
        }

        

        
    }
}
