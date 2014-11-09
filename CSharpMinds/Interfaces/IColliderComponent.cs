using Common;
using System;
namespace CSharpMinds.Interfaces
{
    public interface IColliderComponent : IComponent
    {
        Vector Min { get; }

        Vector Max { get; }

        void OnCollision(IColliderComponent other);
    }
}