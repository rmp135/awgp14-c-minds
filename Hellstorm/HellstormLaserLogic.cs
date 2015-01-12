using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;
using CSharpMinds.Managers;
using CSharpMinds.Components;

namespace Hellstorm
{
    class HellstormLaserLogic : Component, IUpdatable
    {
        PhysicsComponent _phys;
        TransformComponent _trans;
        int _force;

        public HellstormLaserLogic(int force)
        {
            _force = force;
        }
        public int Force
        {
            get { return _force; }
            set { _force = value; }
        }
        public override void Initialise() {
            _phys = Owner.GetComponent<PhysicsComponent>();
            _trans = Owner.GetComponent<TransformComponent>();
        }

        public void Update(GameTime gameTime) {
            if (_trans.Position.X > 1000 || _trans.Position.X < -1000 || _trans.Position.Y < -1000 || _trans.Position.Y > 1000)
                SceneManager.RemoveGameObjectFromScene(Owner);
            _phys.AddForce(new Vector(_force,0));
        }
    }
}
