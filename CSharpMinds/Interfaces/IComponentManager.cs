using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces {
    public interface IComponentManager {
        List<Component> Components { get; }
        void Update();
        void Draw();
    }
}
