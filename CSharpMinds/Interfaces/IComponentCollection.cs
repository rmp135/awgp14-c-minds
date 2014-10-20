using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces {
    public interface IComponentCollection {
        IComponent GetComponentByName(string name);
        IComponent GetComponent<T>() where T : IComponent;
        List<IComponent> Components { get; }
        List<IComponent> ChildComponents { get; }

        void AddComponent(IComponent comp);
        void RemoveComponent(IComponent comp);
    }
}
