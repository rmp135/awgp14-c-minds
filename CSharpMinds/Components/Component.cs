using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds
{
    public abstract class Component : IComponent

    {
        // Private members
        GameObject _owner;
        string _name;

        //Public accessors
        public Component(String name) {
            _name = name;
        }

        public GameObject Owner {
            get { return _owner; }
            set { _owner = value; }
        }

        public String Name {
            get { return _name; }
            set { _name = value; }
        }

        public virtual void Initialise(){}
    }
}
