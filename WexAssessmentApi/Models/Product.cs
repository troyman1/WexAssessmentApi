namespace WexAssessmentApi.Models
{
    public class Product
    {
        private readonly int _id;
        private readonly string _name;
        private readonly decimal _price;
        private readonly string _category;
        private readonly int _stockquantity;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public decimal Price { get { return _price; } }
        public string Category { get { return _category; } }
        public int StockQuantity { get { return _stockquantity; } }
        public Product(int? id, string name, decimal price, string category, int stockquantity)
        {
            _id = id ?? 0; // check for new Id value?
            if (string.IsNullOrEmpty(name))
            {
                ArgumentNullException argumentNullException = new($"{nameof(name)} is required");
                throw argumentNullException;
            }
            if (name.Length > 100) throw new ArgumentException($"{nameof(name)} has a maximum length of 100 characters");
            _name = name;
            if (price < 0) throw new ArgumentException($"{nameof(price)} is negative.");
            _price = price;
            if (string.IsNullOrEmpty(category))
            {
                ArgumentNullException argumentNullException = new($"{nameof(category)} is required");
                throw argumentNullException;
            }
            _category = category;
            if (stockquantity < 0) throw new ArgumentException($"{nameof(stockquantity)} must be a non-negative integer.");
            _stockquantity = stockquantity;
        }
    }
}