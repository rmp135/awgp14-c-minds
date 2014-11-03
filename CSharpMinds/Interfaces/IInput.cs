using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds
{
    //Allows Components to react to different types of input device
    public interface IInput
    {
        void readInput();
    }
}
