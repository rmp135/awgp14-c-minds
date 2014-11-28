﻿using Common;
using ConsoleLibrary.Drivers;
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
                _gravity,
                new WASDControlComponent(),
                new SpriteRenderComponent("Resources\\alienBeige_stand.png"),
                new BoxColliderComponent(66, 92),
                new PlayerCollideLogic()
            });

            GameObject _rayGun = GameObjectFactory.Build("gun", new List<IComponent>() {
                new TransformComponent(){Position = new Vector(30,23)},
                new SpriteRenderComponent("Resources\\raygunBig.png")
            });
            _rayGun.Parent = _player;

            GameObject _fish = GameObjectFactory.Build("fish", new List<IComponent>() {
                new TransformComponent() {Position = new Vector(100,100)},
                new BoxColliderComponent(60,45),
                new SpriteLabelRenderComponent(),
                new SpriteRenderComponent("Resources\\fishGreen.png")
            });

            GameObject _floor = GameObjectFactory.Build(new List<IComponent>() {
                new TransformComponent() {Position = new Vector(0,400)},
                new BoxColliderComponent(800, 20)
            });

            // Add objects to scene. (Note that child objects are automatically added.)
            _scene.AddGameObject(_frameRate);
            _scene.AddGameObject(_player);
            _scene.AddGameObject(_bat);
            _scene.AddGameObject(_fish);
            _scene.AddGameObject(_floor);

            SceneManager.TransitionToScene(_scene);

            for (int i = 0; i < 100000; i++) {

        //        _gravity.AddForce(new Vector(0f, 3f));
                
                //Update

                SceneManager.Update(_gameTime);
                SystemManager.Update(_gameTime);

                _gameTime.Update();

                //Draw
                SystemManager.GetSystem<RenderSystem>().PreRender();

                SceneManager.Render();

                SystemManager.GetSystem<RenderSystem>().PostRender();

                //System.Threading.Thread.Sleep(16);
            }
        }
    }
}