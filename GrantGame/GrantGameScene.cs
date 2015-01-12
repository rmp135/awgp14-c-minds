using CSharpMinds;
using CSharpMinds.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using CSharpMinds.Components;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using GrantGame.Behaviours;
//Import libraries that are required.
using SFMLLibrary.Drivers;


namespace GrantGame
{
    class GrantGameScene : Scene
    {
        public GrantGameScene() : base()
        {
            GameTime _gameTime = new GameTime();
            MedalCollision mc = new MedalCollision();

            //Init systems.

            InputSystem _is = new InputSystem(new SFMLKeyboardDriver());
            _is.setBinding("WALKUP", Keys.keyboard.W);
            _is.setBinding("WALKDOWN", Keys.keyboard.S);
            _is.setBinding("WALKLEFT", Keys.keyboard.A);
            _is.setBinding("WALKRIGHT", Keys.keyboard.D);
            SystemManager.AddSystems(new List<ISystem>(){
                new RenderSystem(new SFMLRenderDriver()),
                _is
            });

            PhysicsComponent _gravity = new PhysicsComponent();

            GameObject _player = GameObjectFactory.Build("player", new List<IComponent>() {
                new TransformComponent(),
                _gravity,
                new PlayerControlComponent(),
                new SpriteRenderComponent("Resources\\alienBeige_stand.png"),
                new BoxColliderComponent(66, 92),
            });

            GameObject _bat = GameObjectFactory.Build("bat", new List<IComponent>() {
                new TransformComponent(),
                new PhysicsComponent(),
                new SpriteRenderComponent("Resources\\bat.png"),
                new BoxColliderComponent(70, 47),
                new PatrollingBehaviour(0,570),
                new CollideWithPlayer(),
            });

            _bat.GetComponent<TransformComponent>().Position = new Vector(200,200);

            GameObject _rayGun = GameObjectFactory.Build("gun", new List<IComponent>() {
                new TransformComponent(){Position = new Vector(30,23)},
                new SpriteRenderComponent("Resources\\raygunBig.png")
            });
            _rayGun.Parent = _player;

            GameObject _fish = GameObjectFactory.Build("fish", new List<IComponent>() {
                new TransformComponent() {Position = new Vector(500,400)},
                new BoxColliderComponent(60,45),
                new TrackingBehaviour(_player),
                new SpriteRenderComponent("Resources\\fishGreen.png"),
                new PhysicsComponent(),
                new CollideWithPlayer(),
            });

            GameObject _medal = GameObjectFactory.Build("medal", new List<IComponent>()
                {
                    new TransformComponent() {Position = new Vector(100,100)},
                    new BoxColliderComponent(41,74),
                    new SpriteRenderComponent("Resources\\flat_medal2.png"),
                    new PhysicsComponent(),
                    mc,
                });

            // Add objects to scene. (Note that child objects are automatically added.)
            AddGameObject(_player);
            AddGameObject(_bat);
            AddGameObject(_fish);
            AddGameObject(_medal);
        }
    }
}


