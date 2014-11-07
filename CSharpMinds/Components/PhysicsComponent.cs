using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CSharpMinds.Components
{
    public class PhysicsComponent : Component, IUpdatable
    {
        Vector _forceAccumulator;
        TransformComponent _transform;

        public PhysicsComponent() : base("PhysicsComponent") {
            _forceAccumulator = new Vector();
        }

        public void Update(GameTime gameTime) {
            _transform.Position += _forceAccumulator;
            _forceAccumulator.X = 0;
            _forceAccumulator.Y = 0;
            _forceAccumulator.Z = 0;
        }
        public void AddForce(Vector forceToAdd) {
            _forceAccumulator += forceToAdd;
        }
        public override void Initialise() {
            _transform = Owner.GetComponent<TransformComponent>() as TransformComponent;
        }
    }
}
