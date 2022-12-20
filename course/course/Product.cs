using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Product
    {
        private double price;
        private string name;

        public Product(double price, string name)
        {
            this.price = price;
            this.name = name;
        }

        public double Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override string ToString()
        {
            return "Product: " + name + " $" + price;
        }
    }
}
