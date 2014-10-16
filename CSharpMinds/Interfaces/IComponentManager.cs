using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces {
    public interface IComponentManager {
        List<IComponent> Components { get; }
        
        IComponent FindWithName(string name);
        void AddComponent(IComponent comp);
        void Update();
        void Draw();
    }
}
