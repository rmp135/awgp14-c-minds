using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    class PlayerCollideLogic : Component
    {
        public override void Initialise() {
            Owner.GetCollider().Collide += new ColliderComponent.CollisionHandler(OnCollision);
        }

        public void OnCollision(ColliderComponent other) {
            Console.WriteLine(other.ToString());
        }
    }
}
