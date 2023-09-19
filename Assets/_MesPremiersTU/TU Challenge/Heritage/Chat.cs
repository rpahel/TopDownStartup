using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        public Chat(string name) : base(name)
        {
            Pattes = 4;
        }

        public new string Crier()
        {
            return "Miaou (j\'ai faim)";
        }
    }
}
