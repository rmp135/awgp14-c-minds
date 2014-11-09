using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;


namespace CSharpMinds.Systems
{
    public class PhysicsSystem : ISystem, IUpdatable
    {
        List<ColliderComponent> _colliders;

        public PhysicsSystem() {
            _colliders = new List<ColliderComponent>();
        }

        public void AddCollider(ColliderComponent collider) {
            _colliders.Add(collider);
        }

        public void Update(GameTime gameTime) {
            for (int i = 0; i < _colliders.Count-1; i++) {
                for (int j = i+1; j < _colliders.Count; j++) {
                    if (hasCollided(_colliders[i], _colliders[j])) {
                        _colliders[i].OnCollide(_colliders[j]);
                        _colliders[j].OnCollide(_colliders[i]);
                    }
                }
            }
        }

        private bool hasCollided(ColliderComponent col1, ColliderComponent col2) {
            if (col1.GetType() == typeof(BoxColliderComponent) && col2.GetType() == typeof(BoxColliderComponent)) {
                return collideBoxWithBox((BoxColliderComponent)col1, (BoxColliderComponent)col2);
            }
            else {
                return false;
            }
        }

        private bool collideBoxWithBox(BoxColliderComponent box1, BoxColliderComponent box2) { 
                if (box1.Max.X <= box2.Min.X) {
                    return false;
                }
                if (box1.Max.Y <= box2.Min.Y) {
                    return false;
                }
                if (box1.Min.X >= box2.Max.X) {
                    return false;
                }
                if (box1.Min.Y >= box2.Max.Y) {
                    return false;
                }
            return true;
        }
    }
}
