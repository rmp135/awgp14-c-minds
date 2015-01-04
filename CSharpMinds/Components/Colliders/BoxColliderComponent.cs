using Common;
using Common.Interfaces;
using CSharpMinds.Managers;
using System;
using CSharpMinds.Systems;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    public class BoxColliderComponent : ColliderComponent, IDrawable
    {
        TransformComponent _transComp;
        private RenderSystem _renderSystem;
        float _width, _height;

        public float Height {
            get { return _height; }
            set { _height = value; }
        }

        public float Width {
            get { return _width; }
            set { _width = value; }
        }
        public override void Initialise() {
            base.Initialise();
            _transComp = Owner.GetComponent<TransformComponent>();
            _renderSystem = SystemManager.GetSystem<RenderSystem>();
        }

        public BoxColliderComponent() { }

        public BoxColliderComponent(float width, float height) {
            _width = width;
            _height = height;
        }

        public override Vector Min {
            get {
                return _transComp.Position;
            }
        }

        public override Vector Max {
            get {
                return new Vector(_transComp.Position.X + _width, _transComp.Position.Y + _height);
            }
        }

        public void Draw() {
            //_renderSystem.DrawLine(new Vector(Min.X, Min.Y), new Vector(Min.X, Max.Y));
            //_renderSystem.DrawLine(new Vector(Min.X, Max.Y), new Vector(Max.X, Max.Y));
            //_renderSystem.DrawLine(new Vector(Max.X, Max.Y), new Vector(Max.X, Min.Y));
            //_renderSystem.DrawLine(new Vector(Max.X, Min.Y), new Vector(Min.X, Min.Y));
        }
    }
}