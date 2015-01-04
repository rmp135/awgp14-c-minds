using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Systems;
using CSharpMinds.Managers;

namespace CSharpMinds.Hellstorm
{
    public class HellstormScene : GameScene
    {
        public HellstormScene() : base()
        {
            //GameObject _player = GameObjectFactory.Build("player",new List<IComponent>() {
            //    new TransformComponent(),
            //    new SpriteRenderComponent("Hellstorm\\Resources\\playerShip1_red.png"),
            //    new HellstormControlComponent(),
            //    new PhysicsComponent(),
            //    new BoxColliderComponent(75, 99)
            //});
            AddGameObject(GameObjectFactory.Build("background", new List<IComponent>() {
                new TransformComponent(),
                new SpriteRenderComponent("Hellstorm\\Resources\\darkPurple.png")
            }));

            GameObject _player = GameObjectFactory.BuildFromXML("Hellstorm\\Resources\\player.xml");
            GameObject _health = GameObjectFactory.Build("health", new List<IComponent>() { new HealthComponent() });
            AddGameObject(_player);
            AddGameObject(_health);
            AddGameObject(GameObjectFactory.Build("spawner", new List<IComponent>() { new EnemySpawner() }));
            AddGameObject(GameObjectFactory.Build("powerupspawner", new List<IComponent>() { new PowerupSpawner() }));
        }
    }
}
