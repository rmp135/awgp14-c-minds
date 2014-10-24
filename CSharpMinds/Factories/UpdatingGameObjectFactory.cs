using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Managers;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;

namespace CSharpMinds.Factories {
    public class UpdatingGameObjectFactory : IGameObjectFactory {
        ComponentManager compman;
        public UpdatingGameObjectFactory(ComponentManager compman)
        {
            this.compman = compman;
        }

        public IGameObject Build() {
            GameObject gc = new GameObject("updating object");
            UpdatingComponent tc = new UpdatingComponent("test");
            gc.AddComponent(tc);
            compman.AddComponent(tc);
            return gc;
        }
    }
}
