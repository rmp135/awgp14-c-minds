using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces {
    public interface IComponentCollection {
        IComponent FindByName(string name);
        List<IComponent> Components { get; }

        void AddComponent(IComponent comp);
        void RemoveComponent(IComponent comp);
    }
}
