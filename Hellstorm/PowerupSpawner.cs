using Common.Interfaces;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Managers;
using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellstorm
{
    class PowerupSpawner : Component, IUpdatable
    {
        public void Update(Common.GameTime gameTime)
        {
            Random r = new Random();
            if (gameTime.TotalTime % 10000 < 15)
            {
                SceneManager.AddGameObjectToScene(GameObjectFactory.Build("health", new List<IComponent>() {
                new TransformComponent(new Common.Vector(700, r.Next(400))),
                new PhysicsComponent(),
                new HellstormLaserLogic(-3),
                new BoxColliderComponent(34, 34),
                new SpriteRenderComponent("Resources\\powerupYellow_bolt.png")
            }));
            }

        }
    }
}
