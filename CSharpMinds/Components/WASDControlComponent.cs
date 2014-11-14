using Common;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System.Collections.Generic;

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
            Owner.Collider.Collide += new ColliderComponent.CollisionHandler(DeleteOnCollide);
        }

        private void DeleteOnCollide(ColliderComponent other) {
            if (_delete)
                SceneManager.RemoveGameObjectFromScene(other.Owner);
        }

        private bool _delete;

        public void Update(GameTime gameTime) {
            if (_inputSystem.isKeyDown(Keys.keyboard.D)) {
                _physComp.AddForce(new Vector(0.2f * gameTime.DeltaTime, 0));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.A)) {
                _physComp.AddForce(new Vector(-0.2f * gameTime.DeltaTime, 0));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.W)) {
                _physComp.AddForce(new Vector(0, -0.2f * gameTime.DeltaTime));
            }
            if (_inputSystem.isKeyDown(Keys.keyboard.S)) {
                _physComp.AddForce(new Vector(0, 0.2f * gameTime.DeltaTime));
            }
            if (_inputSystem.isKeyPressed(Keys.keyboard.Q)) {
                _delete = !_delete;
                System.Console.WriteLine(_delete);
            }

            if (_inputSystem.isKeyPressed(Keys.keyboard.F)) {
                SceneManager.AddGameObjectToScene(GameObjectFactory.Build(new List<IComponent>() {
                    new SpriteRenderComponent("Resources\\laserBlue01.png"),
                    new BoxColliderComponent(9, 54),
                    new TransformComponent(){Position = new Vector(_tranComp.Position.X, _tranComp.Position.Y)}
                }));
            }
        }
    }
}