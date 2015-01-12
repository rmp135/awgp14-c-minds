using Common.Interfaces;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellstorm
{
    class EnemySpawner : Component, IUpdatable
    {
        private string[] _enemies;
        public EnemySpawner()
        {
            _enemies = new string[] { "enemyBlack1","enemyBlack2","enemyBlack3","enemyBlack4","enemyBlack5" };
        }
        public void Update(Common.GameTime gameTime)
        {
            Random r = new Random();
            if (gameTime.TotalTime % 1000 < 15)
            {
                SceneManager.AddGameObjectToScene(GameObjectFactory.Build("enemy", new List<IComponent>() {
                new TransformComponent(new Common.Vector(700, r.Next(400))),
                new PhysicsComponent(),
                new EnemyLogic(),
                new BoxColliderComponent(85, 95),
                new SpriteRenderComponent("Resources\\" + _enemies[r.Next(_enemies.Length)] + ".png")
            }));
            }

        }
    }
}
