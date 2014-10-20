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

        public Scene()
        {
            compmanager = new ComponentManager();
        }

            }
        }

        public ComponentManager CompManager
        {
            get { return compmanager; }
        }

        public void AddGameObject(GameObject go) {
            foreach (IComponent child in go.ChildComponents) {
                compmanager.AddComponent(child);
            }
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
