using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using Common;

//Import libraries that are required.
using ConsoleLibrary.Drivers;
using SFMLLibrary.Drivers;

namespace CSharpMinds
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init systems.
            RenderSystem _renderSystem = new RenderSystem(new SFMLGraphicsDriver());
            InputSystem _inputSystem = new InputSystem(new SFMLKeyboardDriver());
            GameTime _gameTime = new GameTime();

            //Register the systems.
            SystemManager.AddSystem(_renderSystem);
            SystemManager.AddSystem(_inputSystem);

            //Setup a new scene.
            Scene _scene = new Scene();

            PhysicsComponent physics = new PhysicsComponent();
            PhysicsComponent physics2 = new PhysicsComponent();

            GameObject gameobject = GameObjectFactory.Build(new List<IComponent>() { new TransformComponent(), new SpriteRenderComponent("Resources\\appicns_Chrome.png"), physics });
           
            GameObject gameobject2 = GameObjectFactory.Build(new List<IComponent>() { new TransformComponent(), new SpriteRenderComponent("Resources\\appicns_Chrome.png"), physics2 });
            GameObject go3 = GameObjectFactory.Build(new List<IComponent>() { new WASDControlComponent(), new PhysicsComponent(), new TransformComponent(), new SpriteRenderComponent("Resources\\appicns_Firefox.png") });
            _scene.AddGameObject(gameobject);
            _scene.AddGameObject(gameobject2);
            _scene.AddGameObject(go3);
            gameobject.AddChild(go3);

           
            for (int i = 0; i < 100000; i++) {
                SystemManager.Update(_gameTime);

                physics.AddForce(new Vector(0f, 3f));
                physics2.AddForce(new Vector(0f, 1f));

                //Update
                _scene.Update(_gameTime);
                _gameTime.Update();

                //Draw
                _renderSystem.PreRender();

                _scene.Draw();

                _renderSystem.PostRender();

                System.Threading.Thread.Sleep(16);
            }

        }
    }
}
