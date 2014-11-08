using CSharpMinds.Exceptions;
using CSharpMinds.Interfaces;
using System.Collections.Generic;

namespace CSharpMinds
{
    /// <summary>
    /// Handled the links between a GameObject and its components.
    /// </summary>
    public class GameObjectComponentCollection : IComponentCollection
    {
        private List<IComponent> components;
        private GameObject owner;

        /// <summary>
        /// Return all components of the GameObject and all components of the GameObjects children.
        /// </summary>
        public List<IComponent> ChildComponents {
            get {
                List<IComponent> allcomps = components;
                foreach (IComponentCollection child in owner.Children) {
                    allcomps.AddRange(child.ChildComponents);
                }
                return allcomps;
            }
        }

        /// <summary>
        /// Return all components of this GameObject.
        /// </summary>
        public List<IComponent> Components {
            get { return components; }
            set { components = value; }
        }

        public GameObject Owner {
            get { return owner; }
            set { owner = value; }
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
            if (components.Contains(comp)) { return; }
            comp.Owner = this.Owner;
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

        /// <summary>
        /// Return a particular Component from this GameObject.
        /// </summary>
        /// <typeparam name="T">The Component type you wish to retrieve.</typeparam>
        /// <returns>The Component if it exists.</returns>
        public T GetComponent<T>() where T : IComponent {
            T ret = (T)components.Find(p => p.GetType() == typeof(T));
            if (ret == null) { throw new ComponentNotFoundException(typeof(T).ToString()); }
            return ret;
        }
    }
}