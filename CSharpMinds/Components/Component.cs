using CSharpMinds.Exceptions;
using CSharpMinds.Interfaces;
using System;
using System.Xml.Serialization;

namespace CSharpMinds.Components
{
    /// <summary>
    /// Ready made component. Can be inherited from.
    /// </summary>
    public abstract class Component : IComponent
    {
        // Private members
        private GameObject _owner;

        private string _name;

        private bool _enabled;

        /// <summary>
        /// Determines whether the component will be updated and drawn.
        /// </summary>
        public bool Enabled {
            get { return _enabled; }
            set {
                _enabled = value;
            }
        }

        //Public accessors

        /// <summary>
        /// Create a base component with a given name.
        /// </summary>
        /// <param name="name"></param>
        public Component(String name) {
            _name = name;
            _enabled = true;
        }

        /// <summary>
        /// Builds a new Component with a GUID as a name.
        /// </summary>
        public Component()
            : this(Guid.NewGuid().ToString()) {
        }

        /// <summary>
        /// The components Owner (GameObject that this component belogs to.)
        /// </summary>
        [XmlIgnore]
        public GameObject Owner {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// Component name for searching.
        /// </summary>
        public String Name {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// This will performed directly after the constructor.
        /// Used when requiring other components that may not be created when the constructor is called.
        /// </summary>
        public virtual void Initialise() {
        }

        public override string ToString() {
            return (Owner != null) ? _name + " on " + Owner.ToString() : _name;
        }

        /// <summary>
        /// Destroy the Component. Perform cleanup here.
        /// </summary>
        public virtual void Destroy() {
            _owner = null;
        }
    }
}