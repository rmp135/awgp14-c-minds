using CSharpMinds.Exceptions;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using CSharpMinds.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using System.Xml.Serialization;
using Common;

namespace CSharpMinds
{
    /// <summary>
    /// Game Objects have no logic of their own. Offload logic onto components.
    /// </summary>
    public class GameObject
    {
        //Private members.

        private string _name;
        private GameObject _parent;
        private List<GameObject> _children;
        private SerialisableInterfaceList<IComponent> _components;

        //Constructor

        /// <summary>
        /// Return all components of this GameObject.
        /// </summary>
        public SerialisableInterfaceList<IComponent> Components {
            get { return _components; }
            set { _components = value; }
        }

        /// <summary>
        /// The parent of this GameObject.
        /// </summary>
        [XmlIgnore]
        public GameObject Parent {
            get { return _parent; }
            set {
                if (_parent != null && _parent != value) {
                    _parent.RemoveChild(this);
                }
                if (value != null) {
                    value.AddChild(this);
                }

                _parent = value;
            }
        }

        /// <summary>
        /// Return a list of GameObjects that have this object as the parent.
        /// </summary>
        //[XmlIgnore]
        public List<GameObject> Children {
            get { return _children; }
        }

        //Public accessors.
        /// <summary>
        /// Return the name of the game object.
        /// </summary>
        public String Name {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Construct game object with a given name.
        /// </summary>
        /// <param name="name">The name that the GameObject should be called.</param>
        public GameObject(string name) {
            _name = name;
            _components = new SerialisableInterfaceList<IComponent>();
            _children = new List<GameObject>();
        }

        /// <summary>
        /// Construct a game object, a guid will be placed as the name.
        /// </summary>
        public GameObject()
            : this(Guid.NewGuid().ToString()) {
        }

        /// <summary>
        /// Add a child GameObject. This will then move with the parent.
        /// </summary>
        /// <param name="go">The GameObject that you wish to add as a child.</param>
        public void AddChild(GameObject go) {
            if (!_children.Contains(go)) {
                _children.Add(go);
                go.Parent = this;
            }
        }

        /// <summary>
        /// Remove a child GameObject. The child object will still exist but will not move with respect to this object.
        /// </summary>
        /// <param name="go">The GameObject that you wish to remove.</param>
        public void RemoveChild(GameObject go) {
            if (_children.Contains(go)) {
                _children.Remove(go);
                go.Parent = null;
            }
        }

        /// <summary>
        /// Return a particular components by its name.
        /// </summary>
        /// <param name="name">The Component name that you wish to retrieve.</param>
        /// <returns>The Component if it exists.</returns>
        public IComponent GetComponentByName(string name) {
            return Components.Find(p => p.Name == name);
        }

        /// <summary>
        /// Add a Component to the GameObject.
        /// </summary>
        /// <param name="comp">The Component you wish to add.</param>
        public void AddComponent(IComponent comp) {
            if (Components.Contains(comp)) { return; }
            comp.Owner = this;
            Components.Add(comp);
        }

        /// <summary>
        /// Remove a Component from this GameObject.
        /// </summary>
        /// <param name="c">The Component you wish to remove.</param>
        public void RemoveComponent(IComponent c) {
            c.Owner = null;
            Components.Remove(c);
        }

        [XmlIgnore]
        public ColliderComponent Collider {
            get { return (ColliderComponent)Components.Find(p => p.GetType().IsSubclassOf(typeof(ColliderComponent))); }
        }

        /// <summary>
        /// Return all components of the GameObject and all components of the GameObjects children.
        /// </summary>
        [XmlIgnore]
        public List<IComponent> ChildComponents {
            get {
                List<IComponent> allcomps = new List<IComponent>(_components);
                foreach (GameObject child in Children) {
                    allcomps.AddRange(child.ChildComponents);
                }
                return allcomps;
            }
        }

        /// <summary>
        /// Return a particular Component from this GameObject.
        /// </summary>
        /// <typeparam name="T">The Component type you wish to retrieve.</typeparam>
        /// <returns>The Component if it exists.</returns>
        public T GetComponent<T>() where T : IComponent {
            T ret = (T)Components.Find(p => p.GetType() == typeof(T));
            if (ret == null) { throw new ComponentNotFoundException(typeof(T).ToString()); }
            return ret;
        }

        public override string ToString() {
            return Name;
        }

        public void Destroy() {
            foreach (GameObject child in _children) {
                child.Destroy();
            }
            foreach (IComponent comp in _components) {
                comp.Destroy();
            };
        }


        /// <summary>
        /// Initialises this, children and all components.
        /// </summary>
        public void Initialise() {
            foreach (GameObject child in Children) {
                child.Parent = this;
                child.Initialise();
            }
            foreach (IComponent comp in Components) {
                comp.Owner = this;
                try {
                    comp.Initialise();
                }
                catch (ComponentNotFoundException e) {
                    Console.WriteLine(comp + " is missing a " + e.ComponentName + " component dependancy.");
                    comp.Enabled = false;
                }
                catch (SystemNotFoundException e) {
                    Console.WriteLine(comp + " is missing a " + e.SystemName + " system dependancy.");
                    comp.Enabled = false;
                }
            }

        }
    }
}