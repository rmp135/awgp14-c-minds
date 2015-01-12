using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds;
using Common;
using CSharpMinds.Systems;
using CSharpMinds.Managers;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using SFMLLibrary.Drivers;
using CSharpMinds.Resources;
using CSharpMinds.Behaviours;

namespace JackGame
{
    class JackGameScene : Scene
    {
        ScoreComponent score;
        GameObject _fish;
        ScoreHandler sHandler;
        public JackGameScene() : base()
        {
            ResourceManager resourceManager = new ResourceManager();
            resourceManager.LoadBitmap("Resources\\alienBeige_stand.png", "alienBeige");
            resourceManager.LoadBitmap("Resources\\bat.png", "Bat");
            resourceManager.LoadBitmap("Resources\\raygunBig.png", "rayGun");
            resourceManager.LoadBitmap("Resources\\fishGreen.png", "fish");
            resourceManager.LoadBitmap("Resources\\flat_medal2.png", "medal");

            XMLFactory.ReadAndUpdateFromXml<ScoreHandler>("Resources\\Score.xml", sHandler);
            sHandler = new ScoreHandler();
            score = new ScoreComponent((ImageResource)resourceManager.findByName("medal"));
            if (sHandler.score == null || sHandler.score == 0)
            {
                sHandler.score = score.Score;
            }


            //Init systems.

            InputSystem _is = SystemManager.GetSystem<InputSystem>();
            _is.setBinding("WALKUP", Keys.keyboard.UP);
            _is.setBinding("WALKDOWN", Keys.keyboard.DOWN);
            _is.setBinding("WALKLEFT", Keys.keyboard.LEFT);
            _is.setBinding("WALKRIGHT", Keys.keyboard.RIGHT);
            _is.setBinding("FIRE", Keys.keyboard.F);
            _is.setBinding("DELETETOGGLE", Keys.keyboard.Q);

            PhysicsComponent _gravity = new PhysicsComponent();

            GameObject _frameRate = GameObjectFactory.Build(new List<IComponent>() {
                new TransformComponent()
            });

            GameObject scoreObj = GameObjectFactory.Build(new List<IComponent>() {
                new TransformComponent(),
                score
            });

            GameObject _player = GameObjectFactory.Build("player", new List<IComponent>() {
                new TransformComponent(),
                _gravity,
                new PlayerControlComponent(),
                new SpriteRenderComponent(resourceManager.findByName("alienBeige").FilePath),
                new BoxColliderComponent(66, 92),
                new PlayerCollideLogic()
            });

            GameObject _rayGun = GameObjectFactory.Build("gun", new List<IComponent>() {
                new TransformComponent(){Position = new Vector(30,23)},
                new SpriteRenderComponent(resourceManager.findByName("rayGun").FilePath)
            });
            _rayGun.Parent = _player;

            _fish = GameObjectFactory.Build("fish", new List<IComponent>() {
                new TransformComponent() {Position = new Vector(100,100)},
                new BoxColliderComponent(60,45),
                new SpriteRenderComponent(resourceManager.findByName("fish").FilePath),
                new PhysicsComponent(),
                new TrackingBehaviour(_player)
            });

            GameObject _floor = GameObjectFactory.Build(new List<IComponent>() {
                new TransformComponent() {Position = new Vector(0,400)},
                new BoxColliderComponent(800, 20)
            });

            // Add objects to scene. (Note that child objects are automatically added.)
            AddGameObject(_frameRate);
            AddGameObject(_player);
            AddGameObject(_fish);
            AddGameObject(_floor);
            AddGameObject(scoreObj);

            _fish.Collider.Collide += Collider_Collide;

            score.Initialise();
            score.Draw();
        }

        void Collider_Collide(ColliderComponent comp)
        {
            Random rNum = new Random();
            if (comp.Owner.Name == "player")
            {
                score.Score--;
                _fish.GetComponent<TransformComponent>().Position = new Vector(rNum.Next(600), rNum.Next(400));
            }
        }
    }
}