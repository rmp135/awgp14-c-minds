using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using CSharpMinds.Interfaces;

namespace Tests.Mocks
{
    class MockInputDriver : IKeyboardDriver, IUpdatable
    {
        public bool Initialised;
        public bool Updated;

        public bool isKeyDown(Common.Keys.keyboard key) {
            return true;
        }

        public bool isKeyPressed(Common.Keys.keyboard key) {
            return true;
        }

        public void Initialise() {
            Initialised = true;
        }

        public void Update(CSharpMinds.GameTime gameTime) {
            Updated = true;
        }
    }
}
