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
            GameTime _gameTime = new GameTime();

            //Init systems.

            SystemManager.AddSystems(new List<ISystem>() {
                new RenderSystem(new SFMLRenderDriver()),
                new InputSystem(new SFMLKeyboardDriver()),
                new PhysicsSystem()
            });

            //Setup a new scene.
            Scene _scene = new Scene();

            PhysicsComponent _gravity = new PhysicsComponent();

            GameObject _frameRate = GameObjectFactory.Build(new List<IComponent>() {
                new FrameRateComponent(),
                new TransformComponent()
            });

            GameObject _bat = GameObjectFactory.Build("bat", new List<IComponent>() {
                new TransformComponent(),
                new SpriteRenderComponent("Resources\\bat.png"),
                new BoxColliderComponent(70, 47)
            });
            _bat.GetComponent<TransformComponent>().Position = new Vector(200,200);

            GameObject _player = GameObjectFactory.Build("player", new List<IComponent>() {
                new TransformComponent(),
                new PhysicsComponent(),
                new WASDControlComponent(),
                new SpriteRenderComponent("Resources\\alienBeige_stand.png"),
                new PlayerBoxColliderLogic(66, 92)
            });

            GameObject _fish = GameObjectFactory.Build("fish", new List<IComponent>() {
                new TransformComponent() {Position = new Vector(100,100)},
                new BoxColliderComponent(60,45),
                new SpriteLabelRenderComponent(),
                new SpriteRenderComponent("Resources\\fishGreen.png")
            });

            GameObject _medal = GameObjectFactory.Build("medal", new List<IComponent>() {
                new TransformComponent(),
                new SpriteRenderComponent("Resources\\flat_medal2.png")
            });
            _medal.GetComponent<TransformComponent>().Position = new Vector(-5, 10, 0);

            _player.AddChild(_medal);

            // Add objects to scene. (Note that child objects are automatically added.)
            _scene.AddGameObject(_bat);
            _scene.AddGameObject(_player);
            _scene.AddGameObject(_frameRate);
            _scene.AddGameObject(_fish);

            for (int i = 0; i < 100000; i++) {
                SystemManager.Update(_gameTime);

                _gravity.AddForce(new Vector(0f, 3f));

                //Update
                _scene.Update(_gameTime);
                _gameTime.Update();

                //Draw
                SystemManager.GetSystem<RenderSystem>().PreRender();

                _scene.Draw();

                SystemManager.GetSystem<RenderSystem>().PostRender();

                //System.Threading.Thread.Sleep(16);
            }
        }
    }
}