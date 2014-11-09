using Common;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using System;
using CSharpMinds.Systems;

namespace CSharpMinds.Components
{
    internal class BoxColliderComponent : Component, IColliderComponent, IDrawable
    {

        TransformComponent _transComp;
        private RenderSystem _renderSystem;
        float _width, _height;
        public override void Initialise() {
            SystemManager.GetSystem<PhysicsSystem>().AddCollider(this);
            _transComp = Owner.GetComponent<TransformComponent>();
            _renderSystem = SystemManager.GetSystem<RenderSystem>();
        }

        public BoxColliderComponent(float width, float height) {
            _width = width;
            _height = height;
        }

        public Vector Min {
            get {
                return _transComp.Position;
            }
        }

        public Vector Max {
            get {
                return new Vector(_transComp.Position.X + _width, _transComp.Position.Y + _height);
            }
        }

        public virtual void OnCollision(IColliderComponent other) {
        }
        public void Draw() {
            _renderSystem.DrawLine(new Vector(Min.X, Min.Y), new Vector(Min.X, Max.Y));
            _renderSystem.DrawLine(new Vector(Min.X, Max.Y), new Vector(Max.X, Max.Y));
            _renderSystem.DrawLine(new Vector(Max.X, Max.Y), new Vector(Max.X, Min.Y));
            _renderSystem.DrawLine(new Vector(Max.X, Min.Y), new Vector(Min.X, Min.Y));
        }
    }
}