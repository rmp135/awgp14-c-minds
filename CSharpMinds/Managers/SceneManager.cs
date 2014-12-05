using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CSharpMinds.Managers
{
    public static class SceneManager
    {
        static Dictionary<string, Scene> _scenes;
        static Scene _currentScene;
        static bool _paused;

        public static bool Paused
        {
            get { return _currentScene.Paused; }
            set { _currentScene.Paused = value; }
        }
        public static void TransitionToScene(Scene nextScene) {
            _currentScene = nextScene;
        }

        public static void TransitionToScene(String scene)
        {
            _currentScene = _scenes.First(p => p.Key == scene.ToLower()).Value;
        }

        public static void AddScene(Scene sceneToAdd, string name)
        {
            if (_scenes == null) { _scenes = new Dictionary<string, Scene>(); }
            _scenes.Add(name, sceneToAdd);
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
