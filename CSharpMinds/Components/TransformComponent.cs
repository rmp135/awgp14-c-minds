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

        public class TransformPosition {
            private int[] position;
            public TransformPosition() {
                position = new[] { 0, 0, 0 };
            }
            public int X {
                get { return position[0]; }
                set { position[0] = value; }
            }
            public int Y {
                get { return position[1]; }
                set { position[1] = value; }
            }
            public int Z {
                get { return position[2]; }
                set { position[2] = value; }
            }
        }

        TransformPosition position;
        float scale;
        int rotation;


        public TransformPosition Position
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
            position = new TransformPosition();
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
