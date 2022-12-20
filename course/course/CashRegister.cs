using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class CashRegister
    {
        private string index;
        private List<WorkShift> shifts;
        private bool active = true;

        public List<WorkShift> Shifts { get => shifts; set => shifts = value; }
        public bool Active { get => active; set => active = value; }
        public string Index { get => index; set => index = value; }

        public CashRegister(string index, List<WorkShift> shifts)
        {
            this.index = index;
            this.shifts = shifts;
        }

        public CashRegister(string index)
        {
            this.index = index;
            this.shifts = new List<WorkShift>();
        }

        public void addShift(WorkShift shift)
        {
            shifts.Add(shift);
        }

        public List<Worker> getIsolatedWorkers()
        {
            return shifts.Where(s => s.hasCorona(this)).Select(s => { s.Worker.Isolated = true; return s.Worker; }).ToHashSet().ToList();
        }
        
        public WorkShift lastShiftofaCostumer(Worker worker)
        {
            WorkShift result=new WorkShift(DateTime.Today,DateTime.Today,null,null);
            foreach(WorkShift s in shifts)
            {
                if (s.Worker == worker)
                    result = s;

            }
            return result;
        }

        public List<Costumer> getIsolatedClients()
        {
            return shifts.Select(s => s.haveCorona(this)).SelectMany(a =>  { a.ForEach(s => s.Isolated = true); return a; }).ToHashSet().ToList();
        }
        

        public List<Product> shoppedProducts()
        {
            return shifts.Select(s => s.Costumers.Select(c => c.Products).SelectMany(p => p)).SelectMany(p => p).ToHashSet().ToList();
        }

        public List<Worker> getAllWorkers()
        {
            return shifts.Select(s => s.Worker).ToHashSet().ToList();
        }
        public List<Costumer> getAllCostumers()
        {
            return shifts.Select(s => s.Costumers).SelectMany(p => p).ToHashSet().ToList();
        }

        public List<WorkShift> getShiftsOfWorker(Worker worker) 
        {
            return shifts.Where(s => s.Worker.Equals(worker)).ToList();
        }
        public void printShiftsOfWorkers()
        {
            getAllWorkers().ForEach(w => getShiftsOfWorker(w).ForEach(s =>
            {
                Console.WriteLine("Worker: " + w.Name + " Start: " + s.Start + "  End: "  + s.End +"\n");
            }));
        }
        public void printAllClients()
        {
            getAllCostumers().ForEach(w => 
            {
                Console.WriteLine("Costumer: " + w.Name + " Id: " + w.Id + " sick: " + w.Sick+"\n");
            });
        }
        public void printAllProducts()
        {
            shoppedProducts().ForEach(w =>
            {
                Console.WriteLine("Products: " + w.Name + " Price: " + w.Price +"\n");
            });
        }
    }
}
