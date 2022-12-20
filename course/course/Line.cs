using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Line
    {
        private Queue<Costumer> costumersLine;

        public Line()
        {
            costumersLine = new Queue<Costumer>();
        }

        public Queue<Costumer> CostumersLine { get => costumersLine; set => costumersLine = value; }

        public bool Add(Costumer costumer)
         {
            costumersLine.Enqueue(costumer);
            return true;

        }
         public void RemoveCostumer(Costumer costumer)
         { 

            this.costumersLine = new Queue<Costumer>(this.costumersLine.Where(x => !x.Id.Equals(costumer.Id)));
         }
        public void RemoveCostumer(string id)
        {
            this.costumersLine = new Queue<Costumer>(this.costumersLine.Where(x => !x.Id.Equals(id)));
        }
        public void exitFromQueue(string id)
        {
            this.costumersLine.Where(x => x.Id.Equals(id)).ToList().ForEach(c => c.exit());
        }
        public override string ToString()
        {
            string result = "";
            foreach(Costumer costumer in this.costumersLine )
                result += costumer + "\n";
            return result;

        }
    }
}
