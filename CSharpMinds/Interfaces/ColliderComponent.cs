using Common;
using CSharpMinds.Components;
using System;
namespace CSharpMinds.Interfaces
{
    public abstract class ColliderComponent : Component
    {
        public delegate void CollisionHandler(ColliderComponent comp);
        public event CollisionHandler Collide;
        public abstract Vector Min { get; }

        public abstract Vector Max { get; }

        public override void Initialise() {
            base.Initialise();
        }

        public void OnCollide(ColliderComponent message) {
            if (Collide != null)
                Collide(message);
        }
    }
}