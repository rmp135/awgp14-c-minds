using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Managers;

namespace CSharpMinds.Interfaces
{
    public interface IGameObject : IComponentCollection
    {
        string Name { get; }
        GameObject Parent { get; }
        List<GameObject> Children { get; }

        void AddChild(GameObject go);
        void RemoveChild(GameObject go);
    }
}
