using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;

namespace CSharpMinds {
    public class SceneService : ISceneService {

        ComponentManager compmanager;

        public ComponentManager CompManager {
            get { return compmanager; }
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
