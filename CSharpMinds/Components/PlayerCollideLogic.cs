using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;

namespace CSharpMinds.Components
{
    public class PlayerCollideLogic : Component
    {
        PhysicsComponent _phys;
        TransformComponent _trans;
        ColliderComponent _collider;
        public override void Initialise() {
            _collider = Owner.Collider;
            _collider.Collide += new ColliderComponent.CollisionHandler(OnCollision);
            _phys = Owner.GetComponent<PhysicsComponent>();
            _trans = Owner.GetComponent<TransformComponent>();
        }

        public void OnCollision(ColliderComponent other) {

            if (other.Owner.Name == "bat") {
                SceneManager.RemoveGameObjectFromScene(other.Owner);
            }
            Console.WriteLine(other.Owner.ToString());
        }
    }
}
