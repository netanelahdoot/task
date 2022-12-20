using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Test
    {
        public static void TestMain()
        {
            Worker daniel = new Worker("Daniel", "d1", false, false);
            Worker mohamed = new Worker("Mohamed", "d2", false, true);
            Console.WriteLine(mohamed.Bill);
            Product coke = new Product(2.5, "Coca Cola");
            Product pepsi = new Product(2, "Pepsi");
            
            Costumer c1 = new Costumer("n1", "Netanel");
            c1.addProduct(coke);
            
            Costumer c2 = new Costumer("n3", "Gil", true);
            c2.addProduct(coke);
            c2.addProduct(pepsi);

            Costumer c3 =  new Costumer("n3", "Noam");
            c3.addProduct(coke);
            c3.addProduct(coke);

            Costumer c4 = new Costumer("n3", "Mizrahi");
            c4.addProduct(pepsi);
            c4.addProduct(pepsi);


            WorkShift shiftD = new WorkShift(DateTime.Now, DateTime.Now, daniel, new List<Costumer>());
            WorkShift shiftF = new WorkShift(DateTime.Now, DateTime.Now, mohamed, new List<Costumer>());

            Console.WriteLine();
            Console.WriteLine(shiftD);
            Console.WriteLine(shiftF);

            CashRegister r1 = new CashRegister("D1");
            r1.addShift(shiftD);

            CashRegister r2 = new CashRegister("D2");
            r2.addShift(shiftF);



            Store store = new Store(new List<CashRegister> { r1, r2 });
            store.addClient(c1);
            store.addClient(c2);
            store.addClient(c3);
            store.addClient(c4);

            inspect(r1);
            inspect(r2);


            Console.ReadLine();
            Console.Clear();
        }
        public static void TestMain2()
        {
            Worker daniel = new Worker("Daniel", "d1", false, false);
            Product coke = new Product(2.5, "Coca Cola");
            Product pepsi = new Product(2, "Pepsi");

            Costumer c1 = new Costumer("n1", "Netanel");
            c1.addProduct(coke);

            Costumer c2 = new Costumer("n3", "Gil", true);
            c2.addProduct(coke);
            c2.addProduct(pepsi);

            Costumer c3 = new Costumer("n3", "Noam");
            c3.addProduct(coke);
            c3.addProduct(coke);

            List<Costumer> cs = new List<Costumer>
            {
                c1,
                c2,
                c3
            };
            WorkShift shiftD = new WorkShift(DateTime.Now, DateTime.Now, daniel, cs);
            Console.WriteLine(cs);
            printCustomers(cs);
            Console.WriteLine();
            Console.WriteLine(shiftD);

            CashRegister r1 = new CashRegister("D1");
            r1.addShift(shiftD);

            Console.WriteLine(r1.getAllWorkers());
            printWorkers(r1.getAllWorkers());
            Console.WriteLine();

            Console.WriteLine(r1.getIsolatedWorkers());
            printWorkers(r1.getIsolatedWorkers());
            Console.WriteLine();


            Console.WriteLine(r1.getIsolatedClients());
            printCustomers(r1.getIsolatedClients());
            Console.WriteLine();

            Console.WriteLine(cs);
            printCustomers(cs);

            r1.shoppedProducts().ForEach(p => Console.WriteLine(p));
            r1.printShiftsOfWorkers();


            Console.ReadLine();
            Console.Clear();
        }
        public static void inspect(CashRegister r1)
        {
            Console.WriteLine(r1.getAllWorkers());
            printWorkers(r1.getAllWorkers());
            Console.WriteLine();

            Console.WriteLine(r1.Shifts.Last().Costumers.Count);
            printCustomers(r1.Shifts.Last().Costumers);
            Console.WriteLine();

            Console.WriteLine(r1.getIsolatedWorkers());
            printWorkers(r1.getIsolatedWorkers());
            Console.WriteLine();


            Console.WriteLine(r1.getIsolatedClients());
            printCustomers(r1.getIsolatedClients());
            Console.WriteLine();


            r1.shoppedProducts().ForEach(p => Console.WriteLine(p));
            r1.printShiftsOfWorkers();

        }
        public static void printWorkers(List<Worker> people)
        {
            people.ForEach(p => Console.WriteLine(p));
        }

        public static void printCustomers(List<Costumer> people)
        {
            people.ForEach(p => Console.WriteLine(p));
        }
    }
}
