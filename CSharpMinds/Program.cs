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

namespace CSharpMinds
{
    class Program
    {
        static void Main(string[] args)
        {

            GameTime _gameTime = new GameTime();

            SystemManager.AddSystem(new RenderSystem(new ConsoleRenderDriver()));

            Scene scene = new Scene();

            PhysicsComponent physics = new PhysicsComponent();
            PhysicsComponent physics2 = new PhysicsComponent();

            GameObject gameobject = GameObjectFactory.Build(new List<IComponent>() { new TransformComponent(), new TextRenderComponent(), physics });
           
            GameObject gameobject2 = GameObjectFactory.Build(new List<IComponent>() { new TransformComponent(), new TextRenderComponent(), physics2 });
          
            scene.AddGameObject(gameobject);
            scene.AddGameObject(gameobject2);


            for (int i = 0; i < 100000; i++) {
                SystemManager.Update(_gameTime);

                physics.AddForce(new Vector(0f, -0.5f, 0f));
                physics2.AddForce(new Vector(0f, 2f, 0f));

                scene.Update(_gameTime);
                scene.Draw();

                _gameTime.Update();
                System.Threading.Thread.Sleep(100);
            }

        }
    }
}
