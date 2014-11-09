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
        List<IColliderComponent> _colliders;

        public PhysicsSystem() {
            _colliders = new List<IColliderComponent>();
        }

        public void AddCollider(IColliderComponent collider) {
            _colliders.Add(collider);
        }

        public void Update(GameTime gameTime) {
            for (int i = 0; i < _colliders.Count-1; i++) {
                for (int j = i+1; j < _colliders.Count; j++) {
                    if (hasCollided(_colliders[i], _colliders[j])) {
                        _colliders[i].OnCollision(_colliders[j]);
                        _colliders[j].OnCollision(_colliders[i]);
                    }
                }
            }
            
        }
        private bool hasCollided(IColliderComponent col1, IColliderComponent col2) {

                if (col1.Max.X <= col2.Min.X) {
                    return false;
                }
                if (col1.Max.Y <= col2.Min.Y) {
                    return false;
                }
                if (col1.Min.X >= col2.Max.X) {
                    return false;
                }
                if (col1.Min.Y >= col2.Max.Y) {
                    return false;
                }
            return true;
        }
    }
}
