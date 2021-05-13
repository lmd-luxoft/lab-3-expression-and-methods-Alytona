using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class Player
    {
        public readonly string Name;
        public readonly char Symbol;

        public Player (string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
