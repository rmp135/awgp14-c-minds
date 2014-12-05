﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using SFML.Window;
using Common;

namespace SFMLLibrary.Drivers
{
    public class SFMLKeyboardDriver : IKeyboardDriver, IUpdatable
    {
        Dictionary<Keys.keyboard, Keyboard.Key> _keyMappings;
        private List<Keyboard.Key> _pressedKeys;
        private bool renderDriverAvailable;
        public event EventHandler<Keys.keyboard> KeyPressDown;


        public SFMLKeyboardDriver() {
            _keyMappings = new Dictionary<Keys.keyboard, Keyboard.Key>(){
                { Keys.keyboard.A, Keyboard.Key.A},
                { Keys.keyboard.D, Keyboard.Key.D},
                { Keys.keyboard.S, Keyboard.Key.S},
                { Keys.keyboard.W, Keyboard.Key.W},
                { Keys.keyboard.F, Keyboard.Key.F},
                { Keys.keyboard.Q, Keyboard.Key.Q},
                { Keys.keyboard.UP, Keyboard.Key.Up},
                { Keys.keyboard.DOWN, Keyboard.Key.Down},
                { Keys.keyboard.LEFT, Keyboard.Key.Left},
                { Keys.keyboard.RIGHT, Keyboard.Key.Right},
                { Keys.keyboard.RETURN, Keyboard.Key.Return},
                { Keys.keyboard.ESC, Keyboard.Key.Escape},
            };

            _pressedKeys = new List<Keyboard.Key>();
        }

        public void Initialise() {
            try {
            SFMLRenderDriver._window.SetKeyRepeatEnabled(false);
            SFMLRenderDriver._window.KeyPressed += _window_KeyPressed;
            SFMLRenderDriver._window.KeyReleased += _window_KeyReleased;
            renderDriverAvailable = true;
            }
            catch (NullReferenceException) {
                
                Console.WriteLine("SFML Render Driver cannot be found, key press events will not be fired'");
            }

        }

        private void _window_KeyPressed(object sender, KeyEventArgs e) {
        //    KeyPressDown(sender, _keyMappings.First(p => p.Value == e.Code).Key);
           _pressedKeys.Add(e.Code);
        }

        private void _window_KeyReleased(object sender, KeyEventArgs e) {
             _pressedKeys.Remove(e.Code);
        }
        public bool isKeyDown(Keys.keyboard key) {
            Keyboard.Key map;
            _keyMappings.TryGetValue(key, out map);
            return Keyboard.IsKeyPressed(map);
        }
        public bool isKeyPressed(Keys.keyboard key) {
            if (!renderDriverAvailable)
                return isKeyDown(key);
            if (_pressedKeys.Count == 0)
                return false;

            Keyboard.Key map;
            _keyMappings.TryGetValue(key, out map);
            if (_pressedKeys.Contains(map)) {
       //         _pressedKeys.Remove(map);
                return true;
            }
            return false;
        }

        public void Update(GameTime gameTime) {
            if(_pressedKeys.Count > 0)
                _pressedKeys = new List<Keyboard.Key>();
        }
    }
}
