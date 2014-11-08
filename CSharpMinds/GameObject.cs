using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;

namespace CSharpMinds
{
    /// <summary>
    /// Game Objects have no logic of their own. Offload logic onto components.
    /// </summary>
    public class GameObject : GameObjectComponentCollection
    {
        //Private members.

        string name;
        GameObject parent;
        List<GameObject> children;

        //Constructor

        /// <summary>
        /// Construct game object with a given name.
        /// </summary>
        /// <param name="name">The name that the GameObject should be called.</param>
        public GameObject(string name)
        {
            Owner = this;
            this.name = name;
            Components = new List<IComponent>();
            children = new List<GameObject>();
        }

        /// <summary>
        /// Construct a game object, a guid will be placed as the name.
        /// </summary>
        public GameObject() : this(Guid.NewGuid().ToString()) { }

        //Public accessors.

        /// <summary>
        /// Return a list of GameObjects that have this object as the parent.
        /// </summary>
        public List<GameObject> Children {
            get { return children; }
        }

        /// <summary>
        /// Return the name of the game object.
        /// </summary>
        public String Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Add a child GameObject. This will then move with the parent.
        /// </summary>
        /// <param name="go">The GameObject that you wish to add as a child.</param>
        public void AddChild(GameObject go) {
            if (!children.Contains(go)) {
                children.Add(go);
                go.Parent = this;
            }
        }

        /// <summary>
        /// Remove a child GameObject. The child object will still exist but will not move with respect to this object.
        /// </summary>
        /// <param name="go">The GameObject that you wish to remove.</param>
        public void RemoveChild(GameObject go) {
            if (children.Contains(go)) {
                children.Remove(go);
                go.Parent = null;
            }
        }

        /// <summary>
        /// The parent of this GameObject.
        /// </summary>
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

        public override string ToString() {
            return Name;
        }

    }
}
