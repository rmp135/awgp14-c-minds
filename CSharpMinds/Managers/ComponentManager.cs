using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Managers {
    public class ComponentManager : IComponentManager{

        List<Component> components;

        public void Update(){
            foreach (IUpdatable updatable in components) {
                updatable.Update();
            }
        }

        public void Draw() {
            foreach (IDrawable drawable in components) {
                drawable.Draw();
            }
        }

        public List<Component> Components {
            get { return components; }
        }
    }
}
