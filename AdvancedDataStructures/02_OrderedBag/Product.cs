namespace OrderedBag
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price)
            : this()
        {
            this.Name = name;
            this.Price = price;
        }

        public Product()
        {
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1:C}", this.Name, this.Price);
        }
    }
}