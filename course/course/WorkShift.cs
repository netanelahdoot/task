using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class WorkShift
    {
        private DateTime start;
        private DateTime end;
        private Worker worker;
        private List<Costumer> costumers;
        

        public WorkShift(DateTime start, DateTime end, Worker worker, List<Costumer> costumers)
        {
            this.start = start;
            this.end = end;
            this.worker = worker;
            this.costumers = costumers;
        }

        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public Worker Worker { get => worker; set => worker = value; }
        public List<Costumer> Costumers { get => costumers; set => costumers = value; }

        public void addCustomer(Costumer costumer)
        {
            this.costumers.Add(costumer);
        }

        public List<Costumer> haveCorona(CashRegister cashRegister)
        {
            if (costumers.Where(c => c.Sick).ToList().Count == 0) return new List<Costumer>();
            List<Costumer> sicks = new List<Costumer>();
            bool isolate = false;
            for (int i = 0; i < costumers.Count; i++)
            {
                isolate = isolate || costumers[i].Sick || worker.FilterbyisolatedWorker;
                if(isolate)
                {
                    sicks.Add(costumers[i]);
                    worker.FilterbyisolatedWorker = true;
                }
            }
            if(isolate)
            {
                worker.Isolated = true;
            }
            if (cashRegister.lastShiftofaCostumer(worker) == this)
                worker.FilterbyisolatedWorker = false;
            return sicks;
        }
        public bool hasCorona(CashRegister cashRegister)
        {
            WorkShift last = cashRegister.lastShiftofaCostumer(worker);
            if (worker.Sick || worker.FilterbyisolatedWorker)
            {
                worker.Isolated = true;
                if (last == this)
                    worker.FilterbyisolatedWorker = false;
                return true;
            }
            if(costumers.Where(c => c.Sick).ToList().Count > 0)
            {
                worker.Isolated = true;
                worker.FilterbyisolatedWorker = true;

                if (last == this)
                    worker.FilterbyisolatedWorker = false;
                return true;
            } return false;
        }
        public double findDuration()
        {
            TimeSpan ts = end.Subtract(start);
            return ts.TotalSeconds / 3600.0;
        }
        public double findHours()
        {
            if (this.worker.Bill > 0)
                return findDuration();
            return 0;
        }
    }
}
