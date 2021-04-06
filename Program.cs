using System;
using System.Globalization;
using System.Collections.Generic;
using ExercicioPolimorfismo.Entities;

namespace ExercicioPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"Product #{i} data:");
                System.Console.Write("Common, used or import (c/u/i)? ");
                char answer = char.Parse(Console.ReadLine());
                System.Console.Write("Name: ");
                string name = Console.ReadLine();
                System.Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (answer == 'c')
                {
                    Product product = new Product(name, price);
                    list.Add(product);
                }
                else if (answer == 'u')
                {
                    System.Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    Product product = new UsedProduct(name, price, manufactureDate);
                    list.Add(product);
                }
                else
                {
                    System.Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Product product = new ImportedProduct(name, price, customsFee);
                    list.Add(product);
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("PRICE TAGS:");

            foreach (Product p in list)
            {
                System.Console.WriteLine(p.PriceTag());
            }
        }
    }
}
