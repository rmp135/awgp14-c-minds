using Common;
using CSharpMinds.Components;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System;
namespace CSharpMinds.Components
{
    public abstract class ColliderComponent : Component
    {
        public delegate void CollisionHandler(ColliderComponent comp);
        public event CollisionHandler Collide;
        protected PhysicsSystem _physics;
        public abstract Vector Min { get; }

        public abstract Vector Max { get; }

        public override void Initialise() {
            base.Initialise();
            _physics = SystemManager.GetSystem<PhysicsSystem>();
            _physics.AddCollider(this);
        }

        public void OnCollide(ColliderComponent message) {
            if (Collide != null)
                Collide(message);
        }
        public override void Destroy() {
            base.Destroy();
            _physics.RemoveCollider(this);
        }
    }
}