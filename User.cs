using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsCows
{
    public class User
    {
        public string Name { get; set; }
        public char[] Number { get; set; }
        public int Move { get; set; } = 1;
        public int Bulls { get; set; } = 0;
        public int Cows { get; set; } = 0;

        public User(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
