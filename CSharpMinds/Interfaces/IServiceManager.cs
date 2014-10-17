using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces
{
    interface IServiceManager
    {
        List<IService> services { get; }

        IService FindWtihName(string name);
        void AddService(IService service);
        void Remove(IService service);
    }
}
