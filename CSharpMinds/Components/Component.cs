﻿using CSharpMinds.Interfaces;
using System;

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

        public bool Enabled {
            get { return _enabled; }
            set {
                if (!value) {
                    Console.WriteLine(ToString() + " has been disabled.");
                }
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

        public Component()
            : this(Guid.NewGuid().ToString()) {
        }

        /// <summary>
        /// The components Owner (GameObject that this component belogs to.)
        /// </summary>
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
    }
}