using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using SFMLLibrary.Drivers;

namespace Hellstorm
{
    class Hellstorm : Game
    {
        static void Main(string[] args) {
            Hellstorm game = new Hellstorm();
        }

        public override void LoadSystems() {
            SystemManager.AddSystems(new List<ISystem>(){
                new RenderSystem(new SFMLRenderDriver()),
                new InputSystem(new SFMLKeyboardDriver()),
                new PhysicsSystem()
            });
        }
        public override void LoadScenes() {
            SceneManager.AddScene(new HellstormScene(), "game");
            SceneManager.TransitionToScene("game");
        }
    }
}
