using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;
using SFML.Window;
using SFML.Graphics;
using OpenTK;

namespace SFMLLibrary.Drivers
{
    public class SFMLGraphicsDriver : IRenderDriver
    {
        RenderWindow _window;
        Dictionary<string, Sprite> _spriteMaps;
        Dictionary<string, Text> _textMaps;
        Font _font;

        void onclose(object sender, EventArgs args) {
            Environment.Exit(0);
        }

        public SFMLGraphicsDriver() {
            ContextSettings contextSettings = new ContextSettings();
            contextSettings.DepthBits = 32;
            _window = new RenderWindow(new VideoMode(640, 480), "Game", Styles.Titlebar | Styles.Close, contextSettings);
            _spriteMaps = new Dictionary<string,Sprite>();
            _textMaps = new Dictionary<string, Text>();
            _font = new Font(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "/arial.ttf");
            // Make it the active window for OpenGL calls
            _window.SetVerticalSyncEnabled(true);
            _window.SetActive();
           // Toolkit.Init();
           _window.Closed += new EventHandler(onclose);
        }

        private Sprite CacheSprite(string spriteName) {
            Sprite sprite = new Sprite(new Texture(spriteName));
            _spriteMaps.Add(spriteName, sprite);
            return sprite;
        }

        private Text CacheText(string s) {
           Text text = new Text(s, _font, 12);
           _textMaps.Add(s, text);
           return text;
        }

        public void DrawSprite(string spriteName, Vector position) {
            Sprite sprite;
            if (!_spriteMaps.TryGetValue(spriteName, out sprite)) {
                sprite = CacheSprite(spriteName);
            }

            sprite.Position = new Vector2f(position.X, position.Y);
            _window.Draw(sprite);
        }

        public void DrawText(string textToDraw, Vector pos) {
            Text text;
            if (!_textMaps.TryGetValue(textToDraw, out text)) {
                text = CacheText(textToDraw);
            }
            text.Position = new Vector2f(pos.X, pos.Y);
            text.Origin = new Vector2f(0.0f,0.0f);
            text.Color = Color.Black;
            _window.Draw(text);
        }

        public void PreRender() {
            _window.Clear(new Color((byte)50, (byte)50, (byte)180));
        }



        public void PostRender() {
            _window.DispatchEvents();
            _window.Display();
        }
    }
}
