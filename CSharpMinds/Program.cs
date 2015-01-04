using Common;
using ConsoleLibrary.Drivers;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using CSharpMinds.Behaviours;
//Import libraries that are required.
using SFMLLibrary.Drivers;
//
using System.Collections.Generic;
using CSharpMinds.Hellstorm;

namespace CSharpMinds
{
    internal class Program
    {
        private static void Main(string[] args) {
            GameTime _gameTime = new GameTime();

            //Init systems.

            SystemManager.AddSystems(new List<ISystem>(){
                new RenderSystem(new SFMLRenderDriver()),
                new InputSystem(new SFMLKeyboardDriver()),
                new PhysicsSystem()
            });


            //Setup a new scene.
            HellstormScene _scene = new HellstormScene();

            SceneManager.AddScene(_scene, "game");
            SceneManager.TransitionToScene("game");
            for (int i = 0; i < 100000; i++) {

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