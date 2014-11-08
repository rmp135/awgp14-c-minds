using Common;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;

namespace CSharpMinds.Components
{
    public class WASDControlComponent : Component, IUpdatable
    {
        private InputSystem _inputSystem;
        private TransformComponent _tranComp;
        private PhysicsComponent _physComp;

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
                _physComp.AddForce(new Vector(2, 0));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.A)) {
                _physComp.AddForce(new Vector(-2, 0));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.W)) {
                _physComp.AddForce(new Vector(0, -2));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.S)) {
                _physComp.AddForce(new Vector(0, 2));
            }
        }
    }
}
