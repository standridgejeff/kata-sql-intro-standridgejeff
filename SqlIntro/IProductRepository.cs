using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SqlIntro
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void DeleteProduct(int id);
        void InsertProduct(Product prod);
        void UpdateProduct(Product prod);
        IEnumerable<Product> GetProductsWithReviews();
        IEnumerable<Product> GetProductsAndReviews();
    }
}