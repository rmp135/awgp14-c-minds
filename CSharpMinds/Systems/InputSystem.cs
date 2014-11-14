﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Systems
{
    class InputSystem : ISystem
    {
        IKeyboardDriver _driver;
        public InputSystem(IKeyboardDriver driver) {
            _driver = driver;
        }
        public bool isKeyDown(Keys.keyboard key) {
            return _driver.isKeyDown(key);
        }
        public bool isKeyPressed(Keys.keyboard key) {
            return _driver.isKeyPressed(key);
        }

        public void Initialise() {
            _driver.Initialise();
        }

        public void Update(GameTime gameTime) {
            IUpdatable updatable = _driver as IUpdatable;
            if (updatable != null) {
                updatable.Update(gameTime);
            }
        }
    }
}
