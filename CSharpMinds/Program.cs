using Common;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;

//Import libraries that are required.
using SFMLLibrary.Drivers;

//
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

            PhysicsComponent gravity = new PhysicsComponent();

            GameObject _chrome = GameObjectFactory.Build("chrome", new List<IComponent>() { new TransformComponent(), new SpriteRenderComponent("Resources\\appicns_Chrome.png"), gravity });

            GameObject _firefox = GameObjectFactory.Build("firefox", new List<IComponent>() { new TransformComponent(), new PhysicsComponent(), new WASDControlComponent(), new SpriteRenderComponent("Resources\\appicns_Firefox.png") });
            _scene.AddGameObject(_chrome);
            _scene.AddGameObject(_firefox);

            for (int i = 0; i < 100000; i++) {
                SystemManager.Update(_gameTime);

                gravity.AddForce(new Vector(0f, 9.8f));

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