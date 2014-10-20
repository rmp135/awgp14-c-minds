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
    public static class GameObjectFactory
    {

        public static GameObject Build(List<IComponent> components)
        {
            GameObject go = new GameObject(new Guid().ToString());

            foreach (IComponent comp in components) {
                go.AddComponent(comp);
            }
            return go;
        }
    }
}
