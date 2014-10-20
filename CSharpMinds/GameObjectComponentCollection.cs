using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds {
    public class GameObjectComponentCollection : IComponentCollection {

        List<IComponent> components;
        GameObject owner;

        public List<IComponent> Components {
            get { return components; }
            set { components = value; }
        }

        public GameObject Owner {
            get { return owner; }
            set { owner = value; }
        }

        public IComponent GetComponentByName(string name) {
            return Components.Find(p => p.Name == name);
        }

        public void AddComponent(IComponent comp) {
            if (components.Contains(comp)) { return; }
            comp.Owner = this.Owner;
            Components.Add(comp);
        }

        public void RemoveComponent(IComponent c) {
            c.Owner = null;
            Components.Remove(c);
        }

        public IComponent GetComponent<T>() where T : IComponent {
            return components.Find(p => p.GetType() == typeof(T));
        }
    }
}
