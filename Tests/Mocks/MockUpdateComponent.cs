using Common;
using Common.Interfaces;
using CSharpMinds;
using CSharpMinds.Components;
using CSharpMinds.Interfaces;

namespace Tests.Mocks
{
    public class MockUpdateComponent : Component, IUpdatable
    {
        public bool Updated;

        public MockUpdateComponent()
            : base("UpdatingComp") { }

        public string GetTestSring() {
            return "test string";
        }

        public void Update(GameTime gameTime) {
           Updated = true;
        }
    }
}