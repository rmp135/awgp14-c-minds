﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using CSharpMinds.Interfaces;
using Common;

namespace Tests.Mocks
{
    class MockInputDriver : IKeyboardDriver, IUpdatable
    {
        public bool Initialised;
        public bool Updated;

        public bool isKeyDown(Common.Keys.keyboard key) {
            if (key == Common.Keys.keyboard.A) { return true; };
            return false;
        }

        public bool isKeyPressed(Common.Keys.keyboard key) {
            if (key == Common.Keys.keyboard.A) { return true; };
            return true;
        }

        public void Initialise() {
            Initialised = true;
        }

        public void Update(GameTime gameTime) {
            Updated = true;
        }
    }
}
