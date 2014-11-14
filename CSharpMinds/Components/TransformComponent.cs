using Common;
using CSharpMinds.Exceptions;
using System;

namespace CSharpMinds.Components
{
    public class TransformComponent : Component
    {
        private Vector _position;
        private Vector _scale;
        private int _rotation;

        public Vector Position {
            get {
                if (Owner != null && Owner.Parent != null) {
                    TransformComponent parentTrans;
                    try {
                        parentTrans = Owner.Parent.GetComponent<TransformComponent>();
                    }
                    catch (ComponentNotFoundException) {
                        return _position;
                    }
                    return parentTrans.Position + _position;
                }
                return _position;
            }
            set { _position = value; }
        }

        public Vector Scale {
            get { return _scale; }
            set { _scale = value; }
        }

        public int Rotation {
            get { return _rotation; }
            set {
                int absvalue = Math.Abs(value);
                _rotation = absvalue - 360 * (absvalue / 360);
            }
        }

        public TransformComponent()
            : base("Transform") {
            _position = new Vector(0f, 0f, 0f);
            this.Scale = new Vector(1,1,1);
        }
    }
}