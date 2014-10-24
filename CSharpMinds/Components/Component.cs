using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds
{
    public abstract class Component : IComponent, IUpdatable

    {
        // Private members
        GameObject owner;
        string name;

        //Public accessors

        public Component(String name) {
            this.name = name;
        }

        public GameObject Owner {
            get { return owner; }
            set { owner = value; }
        }

        public String Name {
            get { return name; }
            set { name = value; }
        }

        public virtual void Update() { }
    }
}
