using Common.Interfaces;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using CSharpMinds.Interfaces;

namespace Hellstorm
{
    class EnemyLogic : Component, IUpdatable
    {
        TransformComponent _transform;
        PhysicsComponent _physics;
        TransformComponent _playerTransform;
        private float _speed;
        private int _health;
        private double _lastFired;
        public EnemyLogic()
        {
            Random r = new Random();
            _speed = (float)((r.NextDouble() + 0.2) * 0.3);
            _health = r.Next(1, 10);
        }
        public override void Initialise()
        {
            _transform = Owner.GetComponent<TransformComponent>();
            _physics = Owner.GetComponent<PhysicsComponent>();
            _playerTransform = SceneManager.CurrentScene.FindGameObjectByName("player").GetComponent<TransformComponent>();
            Owner.Collider.Collide += Collder_Hit;
        }

        void Collder_Hit(ColliderComponent comp)
        {
            if (comp.Owner.Name != "playerlaser")
                return;
            Common.Vector position = comp.Owner.GetComponent<TransformComponent>().Position;
            SceneManager.RemoveGameObjectFromScene(comp.Owner);
            SceneManager.AddGameObjectToScene(GameObjectFactory.Build(new List<IComponent>() {
                new TransformComponent(new Common.Vector(position.X, position.Y - 20)),
                new LaserHitLogic(),
                new SpriteRenderComponent("Resources\\laserBlue08.png")
            }));
            _health--;
            if (_health < 1)
            {
                SceneManager.RemoveGameObjectFromScene(Owner);
            }
        }

        public void Update(Common.GameTime gameTime)
        {
            if (_transform.Position.X < -200)
            {
                SceneManager.RemoveGameObjectFromScene(Owner);
                return;
            }
            double now = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMilliseconds;
            if (_playerTransform.Position.X < _transform.Position.X &&
                now > _lastFired + 5000 &&
                _playerTransform.Position.Y > _transform.Position.Y-80 &&
                _playerTransform.Position.Y < _transform.Position.Y + 80)
            {
                _lastFired = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMilliseconds;
                SceneManager.AddGameObjectToScene(GameObjectFactory.Build("enemylaser", new List<IComponent>() {
                    new TransformComponent(new Common.Vector(_transform.Position.X-50, _transform.Position.Y + 40)),
                    new PhysicsComponent(),
                    new SpriteRenderComponent("Resources\\laserRed01.png"),
                    new BoxColliderComponent(54,9),
                    new HellstormLaserLogic(-8)
                }));
            }
            _physics.AddForce(new Common.Vector(-_speed * gameTime.DeltaTime, 0));
        }
    }
}
