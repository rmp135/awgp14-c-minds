using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds
{
    /// <summary>
    /// A Scene acts as a collection of Components and GameObject.
    /// </summary>
    public class Scene : IUpdatable, IDrawable
    {
        List<GameObject> _gameObjects;
        List<GameObject> _toAdd;
        List<GameObject> _toRemove;

        public List<GameObject> GameObjects {
            get { return _gameObjects; }
        }

        /// <summary>
        /// Construct a basic scene.
        /// </summary>
        public Scene() {
            _gameObjects = new List<GameObject>();
            _toAdd = new List<GameObject>();
            _toRemove = new List<GameObject>();
        }

        /// <summary>
        /// Remove a GameObject from the scene if it exists.
        /// </summary>
        /// <param name="go">The GameObject that should be removed.</param>
        public void RemoveGameObject(GameObject go) {
            _toRemove.Add(go);
        }

        /// <summary>
        /// Add a GameObject to the scene.
        /// </summary>
        /// <param name="go">The GameObject that should be added.</param>
        public void AddGameObject(GameObject go) {
            _toAdd.Add(go);
        }

        /// <summary>
        /// Find a particular game object by it's name (including generated GUID names).
        /// </summary>
        /// <param name="name">Name of the GameObject to find.</param>
        /// <returns>The found GameObject, or null if not found.</returns>
        public GameObject FindGameObjectByName(string name) {
            return _gameObjects.Find(g => g.Name == name);
        }

        /// <summary>
        /// Update all components of all game objects in the scene, if enabled.
        /// </summary>
        public void Update(GameTime gameTime) {
            performAdditions();
            performRemovals();
            foreach (GameObject go in _gameObjects) {
                foreach (IComponent comp in go.ChildComponents) {
                    IUpdatable updatable = comp as IUpdatable;
                    if (comp.Enabled && updatable != null) {
                        updatable.Update(gameTime);
                    }
                }
            }
        }

        /// <summary>
        /// Add new queued game objects to the scene.
        /// </summary>
        private void performAdditions() {
            if (_toAdd.Count > 0) {
                _gameObjects.AddRange(_toAdd);
                _toAdd = new List<GameObject>();
            }
        }

        /// <summary>
        /// Remove queued removals from the scene.
        /// </summary>
        private void performRemovals() {
            if (_toRemove.Count > 0) {
                foreach (GameObject toremove in _toRemove) {
                    toremove.Destroy();
                    _gameObjects.RemoveAll(g => g == toremove);
                }
                _toRemove = new List<GameObject>();
            }
        }

        public void Destroy() {
            foreach (GameObject gameobject in _gameObjects) {
                gameobject.Destroy();
            }
            _gameObjects = null;
        }

        /// <summary>
        /// Draw the scene.
        /// </summary>
        public void Draw() {
            foreach (GameObject go in _gameObjects) {
                foreach (IComponent comp in go.ChildComponents) {
                    IDrawable drawable = comp as IDrawable;
                    if (comp.Enabled && drawable != null) {
                        drawable.Draw();
                    }
                }
            }
        }
    }
}