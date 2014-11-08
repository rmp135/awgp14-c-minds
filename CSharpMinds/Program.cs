using Common;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;

//Import libraries that are required.
using SFMLLibrary.Drivers;
using System.Collections.Generic;

namespace CSharpMinds
{
    internal class Program
    {
        private static void Main(string[] args) {
            //Init systems.
            RenderSystem _renderSystem = new RenderSystem(new SFMLGraphicsDriver());
            InputSystem _inputSystem = new InputSystem(new SFMLKeyboardDriver());

            GameTime _gameTime = new GameTime();

            //Register the systems.
            SystemManager.AddSystem(_renderSystem);
            SystemManager.AddSystem(_inputSystem);

            //Setup a new scene.
            Scene _scene = new Scene();

            PhysicsComponent physics2 = new PhysicsComponent();

            GameObject gameobject2 = GameObjectFactory.Build(new List<IComponent>() { new TransformComponent(), new SpriteRenderComponent("Resources\\appicns_Chrome.png"), physics2 });

            GameObject go3 = GameObjectFactory.Build("player", new List<IComponent>() { new WASDControlComponent(), new TransformComponent(), new SpriteRenderComponent("Resources\\appicns_Firefox.png") });
            _scene.AddGameObject(gameobject2);
            _scene.AddGameObject(go3);

            for (int i = 0; i < 100000; i++) {
                SystemManager.Update(_gameTime);

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