using CSharpMinds.Components;

namespace Tests.Mocks
{
    public class MockReliesOnComponent : Component
    {
        private MockUpdateComponent _update;

        public override void Initialise() {
            _update = Owner.GetComponent<MockUpdateComponent>();
        }
    }
}