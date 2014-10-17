using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using CSharpMinds.Managers;

namespace CSharpMinds.Factories
{
    public class BasicGameObjectFactory : IGameObjectFactory
    {
        private ComponentManager compman;

        public BasicGameObjectFactory(ComponentManager compman) {
            this.compman = compman;
        }

        public virtual IGameObject Build()
        {
            GameObject go = new GameObject(new Guid().ToString());
            TransformComponent tc = new TransformComponent();
            go.AddComponent(tc);
            compman.AddComponent(tc);
            return go;
        }
    }
}
