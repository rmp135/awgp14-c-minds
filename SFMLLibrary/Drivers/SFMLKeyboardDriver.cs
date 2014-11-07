using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using SFML.Window;
using Common;

namespace SFMLLibrary.Drivers
{
    public class SFMLKeyboardDriver : IKeyboardDriver
    {
        Dictionary<Keys.keyboard, Keyboard.Key> _keyMappings;

        public SFMLKeyboardDriver() {
            _keyMappings = new Dictionary<Keys.keyboard, Keyboard.Key>(){
                { Keys.keyboard.A, Keyboard.Key.A},
                { Keys.keyboard.D, Keyboard.Key.D},
                { Keys.keyboard.S, Keyboard.Key.S},
                { Keys.keyboard.W, Keyboard.Key.W}
            };
        }
        public bool isKeyDown(Keys.keyboard key) {
            Keyboard.Key map;
            _keyMappings.TryGetValue(key, out map);
            return Keyboard.IsKeyPressed(map);
        }
    }
}
