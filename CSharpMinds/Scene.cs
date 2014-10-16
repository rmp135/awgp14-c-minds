using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Factories;

namespace CSharpMinds {
    public class Scene : IScene {

        ComponentManager compmanager;

        //TODO: Remove factory from the scene, or find a more flexible way to use.
        GameObjectFactory factory;

        public Scene()
        {
            compmanager = new ComponentManager();
            factory = new GameObjectFactory(compmanager);
        }

        public ComponentManager CompManager
        {
            get { return compmanager; }
        }

        public GameObjectFactory GOFactory
        {
            get { return factory; }
        }

        public void Update() {
            compmanager.Update();
        }

        public void Draw() {
            compmanager.Draw();
        }
     
        public void Initialise() {
            throw new NotImplementedException();
        }

        public void Denitialise() {
            throw new NotImplementedException();
        }


        public void LoadContent() {
            throw new NotImplementedException();
        }

        public void UnloadContent() {
            throw new NotImplementedException();
        }
    }
}
