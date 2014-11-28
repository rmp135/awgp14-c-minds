using CSharpMinds.Systems;
using CSharpMinds.Interfaces;

namespace Tests.Mocks
{
    internal class MockSystem : ISystem, IUpdatable
    {
        public bool Initialised;
        public bool Updated;
        public void Initialise() {
            Initialised = true;
        }
        public bool DoWork() {
            return true;
        }

        public void Update(CSharpMinds.GameTime gameTime) {
            Updated = true;
        }
    }
}