using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Systems;
using CSharpMinds.Managers;
using Common;

namespace CSharpMinds.Components
{
    public class WASDControlComponent : Component, IUpdatable
    {
        InputSystem _inputSystem;
        TransformComponent _tranComp;
        PhysicsComponent _physComp;
        public WASDControlComponent()
            : base("WASDControl") {

        }
        public override void Initialise() {
            _inputSystem = SystemManager.GetSystem<InputSystem>();
            _tranComp = Owner.GetComponent<TransformComponent>();
            _physComp = Owner.GetComponent<PhysicsComponent>();
        }
        public void Update(GameTime gameTime) {
            if (_inputSystem.isKeyDown(Keys.keyboard.D)) {
                _physComp.AddForce(new Vector(1, 0));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.A)) {
                _physComp.AddForce(new Vector(-1, 0));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.W)) {
                _physComp.AddForce(new Vector(0, -1));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.S)) {
                _physComp.AddForce(new Vector(0, 1));
            }

        }
    }
}
