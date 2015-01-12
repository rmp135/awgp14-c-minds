using CSharpMinds.Components;
using CSharpMinds.Managers;

namespace Tests.Mocks
{
    public class MockReliesOnSystem : Component
    {
        public MockSystem System;

        public override void Initialise() {
            System = SystemManager.GetSystem<MockSystem>();
        }
    }
}