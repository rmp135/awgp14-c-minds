using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Factories;

namespace CSharpMinds {

    /// <summary>
    /// A Scene acts as a collection of Components and GameObject.
    /// </summary>
    public class Scene : IScene {

        private ComponentManager _compmanager;


        /// <summary>
        /// Construct a basic scene.
        /// </summary>
        public Scene()
        {
            _compmanager = new ComponentManager();
        }

        /// <summary>
        /// Remove a GameObject from the scene if it exists.
        /// </summary>
        /// <param name="go">The GameObject that should be removed.</param>
        public void RemoveGameObject(GameObject go) {
            foreach (IComponent comp in go.ChildComponents) {
                _compmanager.RemoveComponent(comp);
            }
        }


        /// <summary>
        /// Add a GameObject to the scene.
        /// </summary>
        /// <param name="go">The GameObject that should be added.</param>
        public void AddGameObject(GameObject go) {
            foreach (IComponent child in go.ChildComponents) {
                _compmanager.AddComponent(child);
            }
        }


        /// <summary>
        /// The scenes Component manager.
        /// </summary>
        public ComponentManager CompManager {
            get { return _compmanager; }
        }

        /// <summary>
        /// Update the scene.
        /// </summary>
        public void Update() {
            _compmanager.Update();
        }

        /// <summary>
        /// Draw the scene.
        /// </summary>
        public void Draw() {
            _compmanager.Draw();
        }
     
        /// <summary>
        /// Initialise the scene.
        /// </summary>
        public void Initialise() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Denitialise the scene.
        /// </summary>
        public void Denitialise() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load any content that is required for the scene.
        /// </summary>
        public void LoadContent() {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Unload any content that the scene no longer requires.
        /// </summary>
        public void UnloadContent() {
            throw new NotImplementedException();
        }
    }
}
