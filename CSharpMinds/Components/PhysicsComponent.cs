using Common;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    public class PhysicsComponent : Component, IUpdatable
    {
        private Vector _forceAccumulator;
        private TransformComponent _transform;

        public PhysicsComponent()
            : base("PhysicsComponent") {
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
            _transform = Owner.GetComponent<TransformComponent>();
        }
    }
}