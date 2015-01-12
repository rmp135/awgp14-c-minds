using CSharpMinds.Factories;
using CSharpMinds;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Systems;
using CSharpMinds.Managers;

namespace Hellstorm
{
    public class HellstormScene : GameScene
    {
        public HellstormScene() : base()
        {
            GameObject _player = GameObjectFactory.Build("player", new List<IComponent>() {
                new TransformComponent(),
                new SpriteRenderComponent("Resources\\playerShip1_red.png"),
                new HellstormControlComponent(),
                new PhysicsComponent(),
                new BoxColliderComponent(75, 99)
            });
            //GameObject _player = GameObjectFactory.BuildFromXML("Hellstorm\\Resources\\player.xml");
            AddGameObject(GameObjectFactory.Build("background", new List<IComponent>() {
                new TransformComponent(),
                new SpriteRenderComponent("Resources\\darkPurple.png")
            }));
            XMLSerialisation.ConstructXML(_player, "Hellstorm\\Resources\\player.xml");
            GameObject _health = GameObjectFactory.Build("health", new List<IComponent>() { new HealthComponent() });
            AddGameObject(_player);
            AddGameObject(_health);
            AddGameObject(GameObjectFactory.Build("spawner", new List<IComponent>() { new EnemySpawner() }));
            AddGameObject(GameObjectFactory.Build("powerupspawner", new List<IComponent>() { new PowerupSpawner() }));
        }
    }
}
