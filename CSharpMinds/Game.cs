using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using CSharpMinds.Managers;
using CSharpMinds.Systems;

namespace CSharpMinds
{
    public class Game
    {
        GameTime _gameTime;
        RenderSystem _renderSystem;

        /// <summary>
        /// Game object. Subclass this to create a new game.
        /// </summary>
        public Game() {
            _gameTime = new GameTime();
            LoadSystems();
            LoadScenes();
            Run();
        }
        /// <summary>
        /// Used for loading the systems. Runs at the start of game generation.
        /// </summary>
        public abstract void LoadSystems() {

        }

        /// <summary>
        /// Used for loading scenes. Runs near the start of game generation, after system loading.
        /// </summary>
        public abstract void LoadScenes() {

        }

        /// <summary>
        /// Updates and draws the screen using the render system.
        /// </summary>
        private void Run() {
            _renderSystem = SystemManager.GetSystem<RenderSystem>();
            while (true)
            {
                Update();
                Draw();
            }
        }

        /// <summary>
        /// Updates all scenes and systems.
        /// </summary>
        private void Update() {
            SceneManager.Update(_gameTime);
            SystemManager.Update(_gameTime);
            _gameTime.Update();
        }

        /// <summary>
        /// Draws the scene.
        /// </summary>
        private void Draw() {
            _renderSystem.PreRender();
            SceneManager.Render();
            _renderSystem.PostRender();
        }
    }
}
