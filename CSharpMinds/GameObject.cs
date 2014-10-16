using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;

namespace CSharpMinds
{
    public class GameObject : GameObjectComponentBridge, IGameObject
    {
        //Private members.

        string name;
        GameObject parent;
        List<GameObject> children;

        //Constructor
        public GameObject(string name)
        {
            Owner = this;
            this.name = name;
            Components = new List<Component>();
            children = new List<GameObject>();
        }

        //Public accessors.

        public List<GameObject> Children {
            get { return children; }
        }

        public String Name {
            get { return name; }
            set { name = value; }
        }

        public void AddChild(GameObject go) {
            if (!children.Contains(go)) {
                children.Add(go);
                go.Parent = this;
            }
        }

        public void RemoveChild(GameObject go) {
            if (children.Contains(go)) {
                children.Remove(go);
                go.Parent = null;
            }
        }

        public GameObject Parent {
            get { return parent; }
            set {
                if (parent != null && parent != value) {
                    parent.RemoveChild(this);
                }
                if (value != null) {
                    value.AddChild(this);
                }

                parent = value;
            }
        }

    }
}
