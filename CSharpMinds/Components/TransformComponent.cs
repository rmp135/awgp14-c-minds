using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Components
{
    public class TransformComponent : Component
    {

        public class TransformPosition {
            private int[] position;
            public TransformPosition() {
                position = new[] { 0, 0 };
            }
            public int X {
                get { return position[0]; }
                set { position[0] = value; }
            }
            public int Y {
                get { return position[1]; }
                set { position[1] = value; }
            }
        }

        TransformPosition position;
        float scale;
        int rotation;


        public TransformPosition Position
        {
            get { return position; }
            set { position = value; }
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
        public TransformComponent():this("Transform") { }
        public TransformComponent(string name):base(name)
        {
            position = new TransformPosition();
            this.Scale = 1;
        }
    }
}
