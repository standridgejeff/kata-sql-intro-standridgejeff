﻿using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductId as Id, Name from product;"; 
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Name = dr["Name"].ToString() };
                }
            }
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM product WHERE ProductID = @id"; //Write a delete statement that deletes by id
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery(); 
            }
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE product SET name = @name WHERE id = @id";
                cmd.Parameters.AddWithValue("@name", prod.Name);
                cmd.Parameters.AddWithValue("@id", prod.Id);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO product (name) VALUES(@name)";
                cmd.Parameters.AddWithValue("@name", prod.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> GetProductsWithReviews()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "Select p.Name, p.ID, pr.Comments FROM product as p" + 
                                  "INNER JOIN productreview as pr ON product.ProductId=productreview.ProductId";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Name = dr["Name"].ToString(), Comments = dr["Comments"].ToString() };
                }
            }
        }
        
        public IEnumerable<Product> GetProductsAndReviews()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM product as p LEFT JOIN productreview as pr ON p.ProductId = pr.ProductId";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                { 
                    yield return new Product { Name = dr["Name"].ToString(), Comments = dr["Comments"].ToString() };
                }

            }

        }
    }
}
