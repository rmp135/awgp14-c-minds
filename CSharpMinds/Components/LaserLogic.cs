using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;
using CSharpMinds.Managers;

namespace CSharpMinds.Components
{
    class LaserLogic : Component, IUpdatable
    {
        PhysicsComponent _phys;
        TransformComponent _trans;
        public override void Initialise() {
            _phys = Owner.GetComponent<PhysicsComponent>();
            _trans = Owner.GetComponent<TransformComponent>();
            Owner.Collider.Collide += Collider_Collide;
        }

        void Collider_Collide(ColliderComponent comp) {
            if (comp.Owner.Name != "player") {
                SceneManager.RemoveGameObjectFromScene(comp.Owner);
                SceneManager.RemoveGameObjectFromScene(Owner);
            }
        }
        public void Update(GameTime gameTime) {
            if (_trans.Position.X > 1000 || _trans.Position.X < -1000 || _trans.Position.Y < -1000 || _trans.Position.Y > 1000)
                SceneManager.RemoveGameObjectFromScene(Owner);
            _phys.AddForce(new Vector(10f,0));
        }
    }
}
