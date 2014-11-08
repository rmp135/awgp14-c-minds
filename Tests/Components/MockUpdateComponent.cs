using CSharpMinds;
using CSharpMinds.Components;
using CSharpMinds.Interfaces;

namespace Tests.Components
{
    public class MockUpdateComponent : Component, IUpdatable
    {
        private int testint;

        public int TestInt { get { return testint; } }

        public MockUpdateComponent()
            : base("UpdatingComp") {
            testint = 0;
        }

        public string GetTestSring() {
            return "test string";
        }

        public void Update(GameTime gameTime) {
            testint++;
        }
    }
}