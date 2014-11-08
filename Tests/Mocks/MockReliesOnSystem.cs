using CSharpMinds.Components;
using CSharpMinds.Managers;

namespace Tests.Mocks
{
    internal class MockReliesOnSystem : Component
    {
        private MockSystem _update;

        public override void Initialise() {
            _update = SystemManager.GetSystem<MockSystem>();
        }
    }
}