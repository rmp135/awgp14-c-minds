using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Managers;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Factories {
    public class UpdatingGameObjectFactory : GameObjectFactory {
        public UpdatingGameObjectFactory(ComponentManager compman) : base(compman) { }

        public override IGameObject Build() {
            GameObject gc =  base.Build() as GameObject;
            TestComponent tc = new TestComponent("test");
            gc.AddComponent(tc);
            compman.AddComponent(tc);
            return gc;
        }
    }
}
