using Common;
using CSharpMinds.Factories;
using Common.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System.Collections.Generic;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;

namespace Hellstorm
{
    public class HellstormControlComponent : Component, IUpdatable
    {
        private InputSystem _inputSystem;
        private TransformComponent _tranComp;
        private PhysicsComponent _physComp;
        private HealthComponent _healthMonitor;

        public override void Initialise() {
            _inputSystem = SystemManager.GetSystem<InputSystem>();
            _tranComp = Owner.GetComponent<TransformComponent>();
            _physComp = Owner.GetComponent<PhysicsComponent>();
            Owner.Collider.Collide += Collider_Hit;
            _inputSystem.setBinding("UP", Common.Keys.keyboard.W);
            _inputSystem.setBinding("DOWN", Common.Keys.keyboard.S);
            _inputSystem.setBinding("LEFT", Common.Keys.keyboard.A);
            _inputSystem.setBinding("RIGHT", Common.Keys.keyboard.D);
            _inputSystem.setBinding("FIRE", Common.Keys.keyboard.F);
        }

        void Collider_Hit(ColliderComponent comp)
        {
            Common.Vector position = comp.Owner.GetComponent<TransformComponent>().Position;
            if (comp.Owner.Name == "enemylaser" || comp.Owner.Name == "enemy")
            {
                _healthMonitor.Health--;
                SceneManager.AddGameObjectToScene(GameObjectFactory.Build(new List<IComponent>() {
                    new TransformComponent(new Common.Vector(position.X, position.Y - 20)),
                    new LaserHitLogic(),
                    new SpriteRenderComponent("Resources\\laserRed10.png")
                }));
                SceneManager.RemoveGameObjectFromScene(comp.Owner);

                if (_healthMonitor.Health == 0)
                {
                    SceneManager.CurrentScene.Paused = true;
                    SceneManager.AddGameObjectToScene(GameObjectFactory.Build(new List<IComponent>() {
                        new TransformComponent(new Common.Vector(230, 200)),
                        new TextRenderComponent("Game Over")
                    }));
                }

            }
            else if (comp.Owner.Name == "health")
            {
                _healthMonitor.Health++;
                SceneManager.RemoveGameObjectFromScene(comp.Owner);
            }
        }


        public void Update(GameTime gameTime) {
            if(_healthMonitor == null)
                _healthMonitor = SceneManager.CurrentScene.FindGameObjectByName("health").GetComponent<HealthComponent>();
            if (_inputSystem.isActionDown("RIGHT") && _tranComp.Position.X < 300)
            {
                _physComp.AddForce(new Vector(0.2f * gameTime.DeltaTime, 0));
            }
            if (_inputSystem.isActionDown("LEFT") && _tranComp.Position.X > 0) {
                _physComp.AddForce(new Vector(-0.2f * gameTime.DeltaTime, 0));
            }
            if (_inputSystem.isActionDown("UP") && _tranComp.Position.Y > 0) {
                _physComp.AddForce(new Vector(0, -0.2f * gameTime.DeltaTime));
            }
            if (_inputSystem.isActionDown("DOWN") && _tranComp.Position.Y < 480 - 99) {
                _physComp.AddForce(new Vector(0, 0.2f * gameTime.DeltaTime));
            }

            if (_inputSystem.isActionPressed("FIRE")) {
                SceneManager.AddGameObjectToScene(GameObjectFactory.Build("playerlaser", new List<IComponent>() {
                    new SpriteRenderComponent("Resources\\laserBlue01.png"),
                    new BoxColliderComponent(54, 9),
                    new TransformComponent(){Position = new Vector(_tranComp.Position.X + 50, _tranComp.Position.Y+50)},
                    new HellstormLaserLogic(10),
                    new PhysicsComponent()
                }));
            }
        }
    }
}