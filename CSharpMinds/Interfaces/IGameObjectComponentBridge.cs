using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces {
    public interface IGameObjectComponentBridge {
        GameObject Owner { get; }
        Component GetComponentByName(string name);
        List<Component> Components { get; }

        void AddComponent(Component comp);
        void RemoveComponent(Component comp);
    }
}
