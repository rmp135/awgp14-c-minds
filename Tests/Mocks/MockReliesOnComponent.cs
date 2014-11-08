using CSharpMinds.Components;

namespace Tests.Mocks
{
    internal class MockReliesOnComponent : Component
    {
        private MockUpdateComponent _update;

        public override void Initialise() {
            _update = Owner.GetComponent<MockUpdateComponent>();
        }
    }
}