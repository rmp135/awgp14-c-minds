using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds;
using CSharpMinds.Systems;
using CSharpMinds.Managers;
using SFMLLibrary.Drivers;
using ConsoleLibrary.Drivers;

namespace Hellstorm
{
    class Hellstorm : Game
    {
        static void Main(string[] args) {
            Hellstorm game = new Hellstorm();
        }

        public override void LoadScenes()
        {
            SceneManager.AddScene(new HellstormScene(), "game");
            SceneManager.TransitionToScene("game");
        }

        public override void LoadSystems() {
            SystemManager.AddSystems(new List<ISystem>(){
                new RenderSystem(new SFMLRenderDriver()),
                new InputSystem(new SFMLKeyboardDriver()),
                new PhysicsSystem()
            });
        }
    }
}
