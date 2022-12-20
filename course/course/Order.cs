using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public enum Status{
        PROCESSING,
        ACCEPTED,
        REJECTED,
        TRANSIT,
        HERE
    };
    public class Order
    {
        private static int counter = 0;
        private readonly string id;
        private readonly Product product;
        private Status status;
        private readonly int quantity;
        private DateTime expirationDate;
        private int sold = 0;

        public Order(Product product, Status status, int quantity)
        {
            this.id = "#" + ++counter;
            this.product = product;
            this.status = status;
            this.quantity = quantity;
            this.expirationDate = DateTime.Now;
        }
        public Order(Product product, Status status, int quantity, DateTime expirationDate)
        {
            this.id = "#" + ++counter;
            this.product = product;
            this.status = status;
            this.quantity = quantity;
            this.expirationDate = expirationDate;
        }

        public Order(string id, Product product, Status status, int quantity, DateTime expirationDate)
        {
            this.id = id;
            this.product = product;
            this.status = status;
            this.quantity = quantity;
            this.expirationDate = expirationDate;
        }

        public int Quantity => quantity;


        public Product Product => product;

        public Status Status { get => status; set => status = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }

        public string Id => id;

        public override string ToString()
        {
            return "Order Id " + id +" " + status.ToString() + " x" + quantity + " " + product.ToString() + " " + expirationDate.ToString();
        }

        public override bool Equals(object obj)
        {
            return id.Equals(id);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public bool expired()
        {
            return DateTime.Now > expirationDate;
        }

        public bool willExpire()
        {
            return DateTime.Now.AddDays(7) > expirationDate;
        }

        public bool sellOne()
        {
            if(++sold >= quantity)
            {
                sold = quantity;
                return false;
            }
            return true;
        }
        public bool sellMany(int q)
        {
            if ((sold+= q) >= quantity)
            {
                sold = quantity;
                return false;
            }
            return true;
        }
        public int avaliableCount()
        {
            if (expired()) return 0;
            return quantity - sold;
        }


    }
}
