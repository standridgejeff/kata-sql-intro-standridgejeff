using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public DapperProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT ProductId as Id, Name from product");
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("DELETE from product WHERE ProductId = @id", new { id });
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("INSERT INTO product (name) VALUES(@name)", new {name = prod.Name});
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("UPDATE product SET name = @name WHERE ProductId = @id", new {name = prod.Name, id = prod.Id});
            }
        }

        public IEnumerable<Product> GetProductsWithReviews()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                const string statement = "SELECT p.ProductID, p.Name, pr.Comments FROM product as p " +
                                         "INNER JOIN productreview as pr ON p.ProductId = pr.ProductId";
                return conn.Query<Product>(statement);
            }
        }

        public IEnumerable<Product> GetProductsAndReviews()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                const string statement ="SELECT p.ProductID as id, p.Name, pr.Comments FROM product as p LEFT JOIN productreview as pr " + 
                                         "ON p.ProductId=pr.ProductId";
                return conn.Query<Product>(statement);
            }
        }
    }
}
