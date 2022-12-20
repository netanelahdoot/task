using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Worker : Person
    {
        public double salary = 30.0;
        public double finePrice = 40.0;
        private double bill;
        private double tempereaure;
        private bool mask;
        private bool filterbyisolatedWorker;

        public double Tempereaure { get => tempereaure; set => tempereaure = value; }
        public double Bill { get => bill; set => bill = value; }
        public bool Mask { get => mask; set => mask = value; }
        public bool FilterbyisolatedWorker { get => filterbyisolatedWorker; set => filterbyisolatedWorker = value; }

        public Worker(string name, string id, bool sick, bool isolated) : base(name, id, sick, isolated)
        {
            filterbyisolatedWorker = false;
            bill = 0.0;
            tempereaure = 36.0;
            mask = true;
            if (isolated)
            {
                makeFine();
            }
        }
        public Worker(string name, string id, bool sick, bool isolated, double tempereaure, bool mask) : base(name, id, sick, isolated)
        {
            filterbyisolatedWorker = false;
            bill = 0.0;
            this.tempereaure = tempereaure;
            this.mask = mask;
            if (this.tempereaure > 38 || isolated || !mask)
            {
                makeFine();
            }
        }
        public void makeFine()
        {
            this.bill += finePrice;
        }
        public void payFine(double hours)
        {
            this.bill -= salary * hours;
            if (bill < 0) bill = 0;
        }
        public override bool Equals(object obj)
        {
            if(obj is Worker)
            {
                return Id.Equals(((Worker)(obj)).Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return "Worker Name: " + Name + " ID: " + Id + " Sick: " + Sick + " Isolated " + Isolated;
        }
        public double billHours()
        {
            return bill / salary;
        }
        public bool canwork()
        {
            return !(this.tempereaure > 38 || this.Isolated || !mask);
        }
    }
}
