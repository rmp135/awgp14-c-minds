using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Managers;

namespace CSharpMinds.Interfaces {
    public interface ISceneService {
        ComponentManager CompManager { get; }
        void LoadContent();
        void Initialise();
        void Update();
        void Draw();
        void Denitialise();
        void UnloadContent();
    }
}
