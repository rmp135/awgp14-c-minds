using CSharpMinds.Systems;
using CSharpMinds.Interfaces;
using Common;
using Common.Interfaces;

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

        public void Update(GameTime gameTime) {
            Updated = true;
        }
    }
}