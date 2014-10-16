using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds {
    public class GameObjectComponentBridge : IGameObjectComponentBridge {

        List<Component> components;
        GameObject owner;

        public List<Component> Components {
            get { return components; }
            set { components = value; }
        }

        public GameObject Owner {
            get { return owner; }
            set { owner = value; }
        }

        public Component GetComponentByName(string name) {
            return Components.Find(p => p.Name == name);
        }

        public void AddComponent(Component comp) {
            if (components.Contains(comp)) { return; }
            comp.Owner = this.Owner;
            Components.Add(comp);
        }

        public void RemoveComponent(Component c) {
            c.Owner = null;
            Components.Remove(c);
        }
    }
}
