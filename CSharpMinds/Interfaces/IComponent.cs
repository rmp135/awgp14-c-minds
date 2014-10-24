using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces
{
    public interface IComponent
    {
        GameObject Owner { get; set; }
        string Name { get; set; }
        void Initialise();
    }
}
