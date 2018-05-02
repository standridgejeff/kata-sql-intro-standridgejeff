using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=Bogglemymind3930!"; //get connectionString format from connectionstrings.com and change to match your database
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
