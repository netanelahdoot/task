using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Costumer : Person
    {
        private List<Product> products;
        private bool inside;

        public Costumer(string id, string name) : base(name, id, false, false){
            this.products = new List<Product>();
            inside = true;
       }

        public Costumer(string id, string name, bool sick) : base(name, id, sick, false) {
            this.products = new List<Product>();
            inside = true;
        }

        public Costumer(string id, string name, bool sick, bool isolated) : base(name, id, sick, isolated) {
            this.products = new List<Product>();
            inside = true;
        }

        public void addProduct(Product p)
        {
            this.products.Add(p);
        }
        public List<Product> Products { get => products; set => products = value; }
        public bool Inside { get => inside; set => inside = value; }

        public override string ToString()
        {
            return "Customer Name: " + Name + " ID: " + Id + " Sick: " + Sick + " debug(isolated=" + Isolated + ")";

        }

        public void exit()
        {
            this.inside = false;
        }

    }
}
