using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Components;
using Common;
using CSharpMinds.Managers;

namespace GrantGame
{
    class CollideWithPlayer : Component
    {
        ColliderComponent _collider;
        TransformComponent _trans;

        public override void Initialise()
        {
            _collider = Owner.Collider;
            _collider.Collide += new ColliderComponent.CollisionHandler(isHit);
            _trans = Owner.GetComponent<TransformComponent>();
        }

        public void isHit(ColliderComponent cc)
        {
            if(cc.Owner.Name == "player")
            {
                SceneManager.RemoveGameObjectFromScene(cc.Owner);
                Console.WriteLine("Game Over");
            }
        }
    }
}
