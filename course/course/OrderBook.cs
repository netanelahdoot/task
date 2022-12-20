using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class OrderBook
    {
        private static OrderBook instance = null;

        private List<Order> book;
        private HashSet<Product> products;

        public List<Order> Book { get => book; set => book = value; }

        private OrderBook()
        {
            this.book = new List<Order>();
            this.products = new HashSet<Product>();
        }
        public static OrderBook getInstance()
        {
            if(instance == null)
            {
                instance = new OrderBook();
            }
            return instance;
        }

        public void addProductNow(Product product, int quantity, DateTime expdate)
        {
            products.Add(product);
            book.Add(new Order(product, Status.HERE, quantity, expdate));
        }
        public void orderProduct(Product product, int quantity)
        {
            products.Add(product);
            book.Add(new Order(product, Status.PROCESSING, quantity));
        }
        public void orderProduct(String name, int quantity)
        {
            orderProduct(products.Where(p => p.Name == name).FirstOrDefault(), quantity);
        }
        public Order getOrder(string id)
        {
            return book.Where(o => o.Id.Equals(id)).FirstOrDefault();
        }
        public List<Order> avaliableOrders(Product p)
        {
            return book.Where(o => !o.expired() && o.Product.Equals(p) && o.Status == Status.HERE).ToList();
        }

        public List<Order> allOrders(Product p)
        {
            return book.Where(o => o.Product.Equals(p)).ToList();
        }

        public List<Order> expiredOrders(Product p)
        {
            return book.Where(o => o.expired() && o.Product.Equals(p)).ToList();
        }

        public int getAvaliable(Product p)
        {
            return avaliableOrders(p).Select(o => o.avaliableCount()).Sum();
        } 

        public bool sellOneProduct(Product p)
        {
            foreach( Order o in avaliableOrders(p))
            {
                if(o.sellOne())
                {
                    return true;
                }
            }
            return false;
        }

        public bool sellManyProducts(Product p, int q)
        {
            foreach (Order o in avaliableOrders(p))
            {
                if (o.sellMany(q))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isInTrouble(Product p)
        {
            int avaliable = getAvaliable(p);
            return avaliable < 20 || avaliableOrders(p).Where(o => o.willExpire()).Select(o=> o.avaliableCount()).Sum() / avaliable >= 0.5 ;
        }

        public List<Product> areInTrouble()
        {
            return products.Where(p => isInTrouble(p)).ToList();
        }

        public void printProductStatus()
        {
            foreach (Product p in products)
            {
                Console.WriteLine("Product " + p.Name + " x" + getAvaliable(p));
            }
        }

        public bool productExists(String name)
        {
            return products.Contains(new Product(0, name));
        }
        public void printOrdersId()
        {
            foreach (Product p in products) 
            {
                allOrders(p).ForEach(o =>
                {
                    Console.WriteLine(p.Name + " x" +  o.Quantity + " => Order: " + o.Id + " - " + o.Status.ToString());
                });
            };
        }
    }
}
