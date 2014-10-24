using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    public class TransformComponent : Component
    {

        public GameObject _owner;

        Vector _position;
        float _scale;
        int _rotation;


        public Vector Position
        {
            get {
                return _position; 
            }
            set { _position = value; }
        }

        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        public int Rotation {
            get { return _rotation; }
            set
            {
                int absvalue = Math.Abs(value);
                _rotation = absvalue - 360 * (absvalue / 360);
            }
        }
        public TransformComponent() : base("Transform")
        {
            _position = new Vector(0f,0f,0f);
            this.Scale = 1;
        }

    }
}
