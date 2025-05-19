using Interface_Quiz.Interfaces;
using Interface_Quiz.Models;

namespace Interface_Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStore market = new Store(10); 

            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. Sell product");
                Console.WriteLine("3. View all products");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Product name: ");
                        string name = Console.ReadLine();

                        Console.Write("Price: ");
                        if (!double.TryParse(Console.ReadLine(), out double price))
                        {
                            Console.WriteLine("Invalid price format.");
                            break;
                        }

                        Console.Write("Count: ");
                        if (!int.TryParse(Console.ReadLine(), out int count))
                        {
                            Console.WriteLine("Invalid count format.");
                            break;
                        }

                        Product newProduct = new Product(name, price, count);
                        market.AddProduct(newProduct);
                        break;

                    case "2":
                        Console.Write("Enter product name to sell: ");
                        string sellName = Console.ReadLine();
                        market.SellProduct(sellName);
                        break;

                    case "3":
                        Console.WriteLine("\nAll products:");
                        foreach (var product in market.Products)
                        {
                            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Count: {product.Count}");
                        }
                        Console.WriteLine($"Total income: {market.TotalIncome}");
                        break;

                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 4.");
                        break;
                }
            }
        }
    }
}
