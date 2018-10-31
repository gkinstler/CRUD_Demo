using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Oct15sandbox
{
    class ProductRepository
    {
        private string connStr = "Server = localhost; Database = bestbuy; Uid = root; Pwd = p@ssw0rd1; SslMode=None";

        public int ID { get; private set; }
        public decimal Price { get; private set; }

        public List<Products> GetAllProducts()
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            List<Products> products = new List<Products>();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID, Name, Price FROM products;";

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Products product = new Products()
                    {
                        ID = (int)dataReader["ProductID"],
                        Name = dataReader["Name"].ToString(),
                        Price = (decimal)dataReader["Price"]
                    };
                    products.Add(product);
                }
                return products;
            }
        }

        public List<Products> GetProductsByName(string Name)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            List<Products> products = new List<Products>();

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID, Name, Price " +
                                  "FROM products " +
                                  "WHERE Name = @xyz " +
                                  "ORDER BY ProductID";

                cmd.Parameters.AddWithValue("xyz", Name);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Products product = new Products()
                    {
                        ID = (int)dataReader["ProductID"],
                        Name = dataReader["Name"].ToString(),
                        Price = (decimal)dataReader["Price"]
                    };

                    products.Add(product);
                }
                return products;
            }
        }

        public Products GetProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID, Name, Price" +
                                  "FROM products " +
                                  "WHERE ProductID= " + id;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    Products product = new Products()
                    {
                        Name = dataReader["Name"].ToString(),
                        ID = (int)dataReader["ProductID"],
                        Price = (decimal)dataReader["Price"],
                    };

                    return product;
                }
                else
                {
                    return null;
                }
            }
        }

        public void CreateProduct(Products prod)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products (Name, Price, CategoryID) Values (@n , @p , @cID);";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.CategoryID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Products prod)
        {
            var conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE products SET Name = @n, Price = @p, CategoryId = @cID " +
                                  "WHERE ProductId = @pID;";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.CategoryID);
                cmd.Parameters.AddWithValue("pID", prod.ProductID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            var conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
