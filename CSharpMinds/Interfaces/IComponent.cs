using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces
{
    public interface IComponent : IUpdatable
    {
        GameObject Owner { get; }
        string Name { get; }
    }
}
