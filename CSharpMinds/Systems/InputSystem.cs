using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;

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
    }
}
