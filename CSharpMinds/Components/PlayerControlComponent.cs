using Common;
using CSharpMinds.Factories;
using Common.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System.Collections.Generic;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    public class PlayerControlComponent : Component, IUpdatable
    {
        private InputSystem _inputSystem;
        private TransformComponent _tranComp;
        private PhysicsComponent _physComp;

        public PlayerControlComponent()
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
            if (_inputSystem.isActionDown("WALKRIGHT")) {
                _physComp.AddForce(new Vector(0.2f * gameTime.DeltaTime, 0));
            }
            if (_inputSystem.isActionDown("WALKLEFT")) {
                _physComp.AddForce(new Vector(-0.2f * gameTime.DeltaTime, 0));
            }
            if (_inputSystem.isActionDown("WALKUP")) {
                _physComp.AddForce(new Vector(0, -0.2f * gameTime.DeltaTime));
            }
            if (_inputSystem.isActionDown("WALKDOWN")) {
                _physComp.AddForce(new Vector(0, 0.2f * gameTime.DeltaTime));
            }
            if (_inputSystem.isActionPressed("DELETETOGGLE")) {
                _delete = !_delete;
                System.Console.WriteLine(_delete);
            }

            if (_inputSystem.isActionPressed("FIRE")) {
                SceneManager.AddGameObjectToScene(GameObjectFactory.Build(new List<IComponent>() {
                    new SpriteRenderComponent("Resources\\laserBlue01.png"),
                    new BoxColliderComponent(54, 9),
                    new TransformComponent(){Position = new Vector(_tranComp.Position.X + 50, _tranComp.Position.Y+50)},
                    new LaserLogic(),
                    new PhysicsComponent()
                }));
            }
        }
    }
}