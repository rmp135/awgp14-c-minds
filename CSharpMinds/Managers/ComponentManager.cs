using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Managers {
    public class ComponentManager : IComponentCollection {

        List<IComponent> components;

        public List<IComponent> Components {
            get { return components; }
        }

        public List<IComponent> ChildComponents {
            get { return Components; }
        }

        public ComponentManager() {
            components = new List<IComponent>();
        }

        public void AddComponent(IComponent comp) {
            components.Add(comp);
        }

        public void RemoveComponent(IComponent comp) {
            components.Remove(comp);
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

        public IComponent GetComponentByName(string name) {
            return components.Find(p => p.Name == name);
        }

        public IComponent GetComponent<T>() where T : IComponent {
            return components.Find(p => p.GetType() == typeof(T));
        }
    }
}
