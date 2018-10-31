using System;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;

namespace Oct15sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository repo = new ProductRepository();

            List<Products> products = repo.GetAllProducts();

            foreach(Products product in products)
            {
                Console.WriteLine(product.ID + " | " + product.Name + " | " + product.Price);
            }

            Console.ReadLine();


            // prompt for new product

            Console.WriteLine("What's the name of the product you want to add: ");

            string newProdName = Console.ReadLine();

            ProductRepository repo = new ProductRepository();

            CreateProduct newProduct = new CreateProduct(newProdName);


            // update existing product

            Console.WriteLine("Select a product that you would like to change: ");

            ProductRepository productRepository = new ProductRepository();

            string ProductID = Console.ReadLine();



            // delete product

            Console.WriteLine("Select a product that you would like to delete: ");

        }
    }
}




ProductRepository repo = new ProductRepository();

string response = Colsole.ReadLine();

while (response != "5")
    {
    Console.WriteLine("Please choose one of the following:");
    Console.WriteLine("1) View Products");
    Console.WriteLine("2) Update a Product");
    Console.WriteLine("3) Create a Product");
    Console.WriteLine("4) Delete a Product");
    Console.WriteLine("5) Exit");   
    
    response = Console.ReadLine();
    
    switch (response)
            {
                case "1":
                    List<Products> products = repo.GetAllProducts();

                foreach(Products product in products)
                {
                Console.WriteLine(product.ID + " | " + product.Name + " | " + product.Price);
                }
                break;

            
                    

