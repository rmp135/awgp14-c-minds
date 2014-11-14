using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Managers
{
    public static class SceneManager
    {
        static Dictionary<string, Scene> _scenes;
        static Scene _currentScene;
        public static void TransitionToScene(Scene nextScene) {
            _currentScene = nextScene;
        }

        public static void AddGameObjectToScene(GameObject go) {
            _currentScene.AddGameObject(go);
        }

        public static void RemoveGameObjectFromScene(GameObject go) {
            _currentScene.RemoveGameObject(go);
        }

        public static void Update(GameTime gameTime) {
            _currentScene.Update(gameTime);
        }

        public static void Render() {
            _currentScene.Draw();
        }
    }
}
