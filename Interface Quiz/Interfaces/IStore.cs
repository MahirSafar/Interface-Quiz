using Interface_Quiz.Models;

namespace Interface_Quiz.Interfaces
{
    interface IStore
    {
        Product[] Products { get; }
        int ProductLimit { get; }
        double TotalIncome { get; }

        void AddProduct(Product product);
        void SellProduct(string name);
    }

}
