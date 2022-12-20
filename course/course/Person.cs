using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Person
    {
        private string name;
        private string id;
        private bool sick;
        private bool isolated;

        public Person(string name, string id, bool sick, bool isolated)
        {
            this.name = name;
            this.id = id;
            this.sick = sick;
            this.isolated = isolated;
        }

        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public bool Sick { get => sick; set => sick = value; }
        public bool Isolated { get => isolated; set => isolated = value; }

        public override string ToString()
        {
            return "Name: " + Name + " ID: " + Id + " Sick: " + Sick + " Isolated " + Isolated;
        }
    }
}
