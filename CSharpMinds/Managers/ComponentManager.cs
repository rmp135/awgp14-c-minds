using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Managers {
    public class ComponentManager : IComponentManager{

        List<IComponent> components;

        public List<IComponent> Components {
            get { return components; }
        }

        public ComponentManager()
        {
            components = new List<IComponent>();
        }

        public void AddComponent(IComponent comp) {
            components.Add(comp);
        }

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

        public IComponent FindWithName(string name)
        {
            return components.Find(p => p.Name == name);
        }
    }
}
