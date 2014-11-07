using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Managers {
    public class ComponentManager : IComponentCollection, IUpdatable {

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

        public void Update(GameTime gameTime){
            foreach (IComponent comp in components) {
                if (comp is IUpdatable) {
                    ((IUpdatable)comp).Update(gameTime);
                }
            }
        }

        public void Draw() {
            foreach (IComponent comp in components) {
                if (comp is IDrawable) {
                    ((IDrawable)comp).Draw();
                }
            }
        }

        public IComponent GetComponentByName(string name) {
            return components.Find(p => p.Name == name);
        }

        public T GetComponent<T>() where T : IComponent {
            return (T)components.Find(p => p.GetType() == typeof(T));
        }
    }
}
