using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Systems
{
    public class InputSystem : ISystem
    {
        IKeyboardDriver _driver;

        Dictionary<String, Keys.keyboard> _bindings;

        public InputSystem(IKeyboardDriver driver) {
            _driver = driver;
            _bindings = new Dictionary<string, Keys.keyboard>();
        }

        public void setBinding(String actionName, Keys.keyboard key) {
            _bindings.Add(actionName, key);
        }

        public bool isActionDown(String action) {
            Keys.keyboard key;
            _bindings.TryGetValue(action, out key);
            if (key != Keys.keyboard.NONE) {
                return isKeyDown(key);
            }
            return false;
        }

        public bool isActionPressed(String action) {
            Keys.keyboard key;
            _bindings.TryGetValue(action, out key);
            if (key != Keys.keyboard.NONE) {
                return isKeyPressed(key);
            }
            return false;
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
