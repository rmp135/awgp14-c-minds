using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Managers;
using CSharpMinds.Factories;

namespace CSharpMinds.Interfaces {
    public interface IScene {
        ComponentManager CompManager { get; }
        void AddGameObject(GameObject go);
        void RemoveGameObject(GameObject go);
        void LoadContent();
        void Initialise();
        void Update();
        void Draw();
        void Denitialise();
        void UnloadContent();
    }
}
