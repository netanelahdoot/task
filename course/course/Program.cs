using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Program
    {
        static Line line;
        static OrderBook book;
        static Store store;
        static void Main(string[] args)
        {
            line = new Line();
            book = OrderBook.getInstance();

            Product coke = new Product(2.5, "Coca Cola");
            Product pepsi = new Product(2, "Pepsi");
            Product icecream = new Product(10, "ice cream");
            Product chips = new Product(5, "chips");
            Product beef = new Product(50, "beef");
            Product chicken = new Product(25, "chicken");

            Costumer Netanel = new Costumer("214294944", "Netanel");
            Netanel.addProduct(coke);
            Netanel.addProduct(chips);
            Netanel.addProduct(icecream);
            Netanel.addProduct(chicken);

            Costumer ori = new Costumer("020384759", "ori");
            ori.addProduct(coke);
            ori.addProduct(chips);

            Costumer habibi = new Costumer("553453659", "habibi");
            habibi.addProduct(pepsi);

            Costumer nayef = new Costumer("999999999", "nayef", false);
            nayef.addProduct(beef);
            nayef.addProduct(chicken);

            Costumer messi = new Costumer("123535699", "messi", false);
            messi.addProduct(beef);
            messi.addProduct(icecream);
            messi.addProduct(chicken);

            Costumer ronaldo = new Costumer("467535799", "ronaldo", false);
            ronaldo.addProduct(pepsi);

            Costumer christiano = new Costumer("988899999", "christiano");
            christiano.addProduct(coke);

            Worker daniel = new Worker("Daniel", "989898999", false, false);
            Worker mohamed = new Worker("Mohamed", "138964596", false, false);

            List<Costumer> Line1 = new List<Costumer>();
            Line1.Add(ori);
            Line1.Add(habibi);
            List<Costumer> Line2 = new List<Costumer>();
            Line2.Add(nayef);
            Line2.Add(ori);
            Line2.Add(Netanel);
            List<Costumer> Line3 = new List<Costumer>();
            Line3.Add(habibi);
            Line3.Add(messi);
            List<Costumer> Line4 = new List<Costumer>();
            Line4.Add(ronaldo);
            Line4.Add(christiano);
            WorkShift shiftD2 = new WorkShift(new DateTime(2022, 12, 17, 8, 0, 0), new DateTime(2022, 12, 17, 16, 0, 0), daniel, Line1);
            WorkShift shiftM2 = new WorkShift(new DateTime(2022, 12, 17, 8, 0, 0), new DateTime(2022, 12, 17, 16, 0, 0), mohamed, Line3);
            
            WorkShift shiftD1 = new WorkShift(new DateTime(2022, 12, 13, 8, 0, 0), new DateTime(2022, 12, 13, 22, 0, 0), daniel, Line4);
            WorkShift shiftM1 = new WorkShift(new DateTime(2022, 12, 14, 8, 0, 0), new DateTime(2022, 12, 14, 22, 0, 0), mohamed, Line2);
            List<WorkShift> workShifts1 = new List<WorkShift>();
            workShifts1.Add(shiftD1);
            workShifts1.Add(shiftD2);
            List<WorkShift> workShifts2 = new List<WorkShift>();
            workShifts2.Add(shiftM1);
            workShifts2.Add(shiftM2);
            CashRegister cashRegister = new CashRegister("1", workShifts1);
            CashRegister cashRegister2 = new CashRegister("2", workShifts2);
            List<CashRegister> registers = new List<CashRegister>();
            registers.Add(cashRegister);
            registers.Add(cashRegister2);
            store = new Store(registers);


            Mainloop();
            //Test.TestMain();
        }
        static void Mainloop()
        {
            showHelp();
            int x = 0;
            while(x != 9 && (x = int.Parse(Console.ReadLine()))!= 9)
            {
                x = parseX(x);
                if(x ==8)
                {
                    showHelp();
                }
            }
            Console.Clear();
        }
        static int parseX(int x)
        {
                switch (x)
                {
                    case 1: { x = manageCustomers(x); } break;
                    case 2: { x = manageCashRegisters(x); } break;
                    case 3: { x = manageWorkers(x); } break;
                    case 4: { x = manageCorona(x); } break;
                    case 5: { x = manageProducts(x);  } break; 
                    case 8: {
                        showHelp();
                        } break;
                    default: break;
                }
            return x;
        }
        static void showHelp()
        {
            Console.Clear();
            Console.WriteLine("Press 1 for Customer Management");
            Console.WriteLine("Press 2 for Cash Register Management");
            Console.WriteLine("Press 3 for Worker Management");
            Console.WriteLine("Press 4 for Corona Insights");
            Console.WriteLine("Press 5 for Product/Order Management");
            Console.WriteLine("Press 8 for going back to the main menu");
            Console.WriteLine("Press 9 for Exit the program");
        }
        static int manageCustomers(int x)
        {
            Console.Clear();
            Console.WriteLine("Press 1 is for adding a new customer");
            Console.WriteLine("Press 2 is for adding x customers to the store");
            Console.WriteLine("Press 3 to show the line");
            Console.WriteLine("press 8 to return to the main menu ");

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9) {
                Console.Clear();
                if (x == 1)
                {
                    Console.WriteLine("if the costumer isn't supposed to be isolated please press 1 else press 0");
                    int result = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (result == 0)
                    {
                        Console.WriteLine("sorry but he cannot join the line, please press enter");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("what's his temperature");
                        result = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (result > 38)
                        {
                            Console.WriteLine("sorry but he cannot join the line, please press enter");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("does he have mask on him, if yes press 1 if no press 0");
                            result = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (result == 0)
                            {
                                Console.WriteLine("sorry but he cannot join the line, please press enter");
                                Console.ReadLine();
                            }
                            else
                            {

                                Console.WriteLine("please enter the costumer's First Name and then press enter");
                                string firstName = Console.ReadLine();
                                Console.WriteLine("please enter the costumer's Last Name and then press enter");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("please enter the costumer's ID and then press enter");
                                string id = Console.ReadLine();
                                Console.WriteLine("do you want him to be sick if yes press 1 else press 0");
                                int sick = int.Parse(Console.ReadLine());
                                if (sick == 1)
                                    line.Add(new Costumer(id, firstName + " " + lastName, true));
                                else
                                    line.Add(new Costumer(id, firstName + " " + lastName, false));


                                Console.WriteLine("costumer has been added to the line");
                            }
                        }

                    }
                }
                if (x == 2)
                {
                    Console.Clear();
                    Console.WriteLine("how many costumer do you want to add to the store");
                    int numberofCostumers = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Queue<Costumer> costumers = line.CostumersLine;
                    for (int i = 0; i < numberofCostumers; i++)
                    {
                        costumers.Dequeue();
                    }
                }
                if (x == 3)
                {
                    if (line.CostumersLine.Count == 0)
                        Console.WriteLine("there are no costumers");
                    else
                    {
                        Console.WriteLine(line);

                    }
                }
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("To add another costumer press 1");
                Console.WriteLine("press 2 to add costumers to the store");
                Console.WriteLine("press 3 to show the line");
                Console.WriteLine("press 8 to return to the main menu ");
            
            }
            return x;
        }
        static int manageWorkers(int x)
        {
            Console.Clear();
            Console.WriteLine("press 1 to");
            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                Console.Clear();
            }
            return x;
        }
        static int manageProducts(int x)
        {
            Console.Clear();

            Console.WriteLine("press 1 to order a Product");
            Console.WriteLine("press 2 to list all Products");
            Console.WriteLine("press 3 to list all Orders Id");
            Console.WriteLine("press 4 to track a Product Order");
            Console.WriteLine("press 5 to change an Order Status");

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                switch(x)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Product Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Quantity:");
                            int q = int.Parse(Console.ReadLine());
                            if (book.productExists(name))
                            {
                                book.orderProduct(name, q);
                                Console.WriteLine("Order Created Sucessfuly");
                            }
                            else
                            {
                                Console.WriteLine("Price:");
                                double price = double.Parse(Console.ReadLine());
                                book.orderProduct(new Product(price, name), q);
                                Console.WriteLine("Order and Product Created Sucessfuly");
                            }
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            book.printProductStatus();
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            book.printOrdersId();
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Order ID :");
                            String id = Console.ReadLine();
                            Order o = book.getOrder(id);
                            if (!id.StartsWith("#")){
                                o = book.getOrder("#" + id);
                            }
                            if (o == null)
                            {
                                Console.WriteLine("Order doesn't exist!");
                            }
                            else {
                                Console.WriteLine(o.ToString());
                            }
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Order ID :");
                            String id = Console.ReadLine();
                            Order o = book.getOrder(id);
                            if (!id.StartsWith("#"))
                            {
                                o = book.getOrder("#" + id);
                            }
                            if (o == null)
                            {
                                Console.WriteLine("Order doesn't exist!");
                            }
                            else
                            {
                                Console.WriteLine("Order Found:");
                                Console.WriteLine(o.ToString());
                                Console.WriteLine("Change status to:");
                                Console.WriteLine("1 = PROCESSING");
                                Console.WriteLine("2 = ACCEPTED");
                                Console.WriteLine("3 = REJECTED");
                                Console.WriteLine("4 = TRANSIT");
                                Console.WriteLine("5 = HERE");
                                int s= int.Parse(Console.ReadLine());
                                switch (s)
                                {
                                    case 1:
                                        {

                                            o.Status = Status.PROCESSING;
                                        } break;

                                    case 2:
                                        {

                                            o.Status = Status.ACCEPTED;
                                        }
                                        break;
                                    case 3:
                                        {

                                            o.Status = Status.REJECTED;
                                        }
                                        break;
                                    case 4:
                                        {

                                            o.Status = Status.TRANSIT;
                                        }
                                        break;

                                    case 5:
                                        {

                                            o.Status = Status.HERE;
                                        }
                                        break;
                                }
                            }
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                }
                Console.Clear();

                Console.WriteLine("press 1 to order a Product");
                Console.WriteLine("press 2 to list all Products");
                Console.WriteLine("press 3 to list all Orders");
                Console.WriteLine("press 4 to track a Product Order");
                Console.WriteLine("press 5 to change an Order Status");
                Console.WriteLine("press 8 to return to the main menu ");
            }
            return x;
        }
        static int manageCashRegisters(int x)
        {
            Console.Clear();
            Console.WriteLine("Press 1 to see all the costumer and all the product from all the cash registers");
            Console.WriteLine("Press 2 is to see all the shifts of work of all the workers");
            Console.WriteLine("Press 3 to report a sick costumer");
            Console.WriteLine("Press 4 to see all the isolated costumers and workers");
            Console.WriteLine("press 8 to return to the main menu ");

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                Console.Clear();
                switch(x)
                {
                    case 1:
                        {
                            
                            store.printallClients();
                            
                            store.printallProducts();
                        }
                        break;
                    case 2:
                        {
                            store.printallShiftsOfWorkers();
                        }
                        break;
                    case 3:
                        {
                            costumertoSick();
                        }
                        break;
                    case 4:
                        {

                            Console.WriteLine("these are all the isolated workers:" + "\n");
                            store.printIsolatedWorkers();
                            Console.WriteLine("these are all the isolated costumers:" + "\n");
                            store.printIsolatedClients();
                            
                        }
                        break;


                }
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Press 1 to see all the costumer and all the product from all the cash registers");
                Console.WriteLine("Press 2 is to see all the shifts of work of all the workers");
                Console.WriteLine("Press 3 to report a sick costumer");
                Console.WriteLine("Press 4 to see all the isolated costumers and workers");
                Console.WriteLine("press 8 to return to the main menu ");


            }
                return x;
        }
        static void costumertoSick()
        {
            Console.Clear();
            Console.WriteLine("please enter the id of the sick costumer, and press 9 to return");
            string id = "";
            while (!id.Equals("9") && !(id = Console.ReadLine()).Equals("9"))
            {
                if (id.Length != 9)
                    Console.WriteLine("sorry but the id is not valid please enter again");
                else
                    store.changeCostumerToSick(id);
            }
            
        }
        static int manageCorona(int x)
        {
            Console.Clear();

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                Console.Clear();
            }
            return x;
        }
    }
}
