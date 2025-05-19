using Interface_Quiz.Interfaces;

namespace Interface_Quiz.Models
{
    class Store : IStore
    {
        private Product[] _products;
        private int _currentCount = 0;

        public Product[] Products
        {
            get
            {
                Product[] current = new Product[_currentCount];
                for (int i = 0; i < _currentCount; i++)
                {
                    current[i] = _products[i];
                }
                return current;
            }
        }

        public int ProductLimit { get; private set; }
        public double TotalIncome { get; private set; }

        public Store(int productLimit)
        {
            ProductLimit = productLimit;
            _products = new Product[ProductLimit];
        }

        public void AddProduct(Product product)
        {
            if (_currentCount >= ProductLimit)
            {
                Console.WriteLine("Product limit reached. Cannot add more products.");
                return;
            }

            for (int i = 0; i < _currentCount; i++)
            {
                if (_products[i].Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Product with this name already exists.");
                    return;
                }
            }

            _products[_currentCount] = product;
            _currentCount++;
            Console.WriteLine("Product added successfully.");
        }

        public void SellProduct(string name)
        {
            for (int i = 0; i < _currentCount; i++)
            {
                if (_products[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    if (_products[i].Count > 0)
                    {
                        _products[i].Count--;
                        TotalIncome += _products[i].Price;
                        Console.WriteLine($"{name} sold for {_products[i].Price}.");
                    }
                    else
                    {
                        Console.WriteLine("This product is out of stock.");
                    }
                    return;
                }
            }

            Console.WriteLine("Product not found.");
        }
    }

}
