﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DapperExercise;
class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
        string connString = config.GetConnectionString("DefaultConnection");

        IDbConnection conn = new MySqlConnection(connString);
        var repo = new DapperDepartmentRepository(conn);
        var prodRepo = new DapperProductRepository(conn);

        // Exercise 1

        Console.WriteLine("Type a new Department name: ");

        var newDepartment = Console.ReadLine();

        repo.InsertDepartment(newDepartment);

        var departments = repo.GetAllDepartments();
        Console.WriteLine("All Departments\n");
        foreach (var dept in departments)
        {
            Console.WriteLine(dept.Name);
        }

        // Exercise 2

        Console.WriteLine("Type a new Product name: ");

        string newProductName = Console.ReadLine();

        Console.WriteLine("Enter the price of the new Product: ");

        double newProductPrice = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the ProductID of the new Product: ");

        int newProductID = int.Parse(Console.ReadLine());

        prodRepo.CreateProduct(newProductName, newProductPrice, newProductID);

        var products = prodRepo.GetAllProducts();
        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.Name} {prod.ProductID} {prod.Price}");
        }

        // Update Product Bonus

        Console.WriteLine("Enter a ProductID to update: ");
        var prodID = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the updated name: ");
        var updatedName = Console.ReadLine();

        prodRepo.UpdateProduct(prodID, updatedName);
        products = prodRepo.GetAllProducts();
        Console.WriteLine("All Products\n");

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }

        Console.WriteLine();

        // Delete Product Bonus

        Console.WriteLine("What is the ProductID you want to delete?");
        prodID = int.Parse(Console.ReadLine());
        prodRepo.DeleteProduct(prodID);
        products = prodRepo.GetAllProducts();
        Console.WriteLine("All Products\n");

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }
    }
}

