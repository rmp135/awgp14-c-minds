using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSharpMinds.Interfaces
{
    class KeyBoardInput : IInput
    {
        ConsoleKeyInfo cki;

        public void readInput()
        {
            cki = Console.ReadKey();
            if (cki.Key != ConsoleKey.Escape)
            {
                //Do Stuff
            }
            else
            {
                Console.WriteLine("End Program"); 
            }
        }
    }
}
