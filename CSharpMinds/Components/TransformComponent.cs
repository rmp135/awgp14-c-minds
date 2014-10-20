using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    public class TransformComponent : IComponent
    {

        public GameObject owner;

        Vector position;
        float scale;
        int rotation;


        public Vector Position
        {
            get {
                return position; 
            }
        }

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public int Rotation {
            get { return rotation; }
            set
            {
                int absvalue = Math.Abs(value);
                rotation = absvalue - 360 * (absvalue / 360);
            }
        }
        public TransformComponent()
        {
            position = new Vector(0f,0f,0f);
            this.Scale = 1;
        }

        public GameObject Owner {
            get { return owner; }
            set { owner = value; }
        }

        public string Name {
            get { return "Transform"; }
            set { }
        }
    }
}
