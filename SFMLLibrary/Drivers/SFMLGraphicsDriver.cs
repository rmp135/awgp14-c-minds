using Common;
using Common.Interfaces;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace SFMLLibrary.Drivers
{
    public class SFMLRenderDriver : IRenderDriver
    {
        internal static RenderWindow _window;
        private Dictionary<string, Sprite> _spriteMaps;
        private Dictionary<string, Text> _textMaps;
        private Font _font;

        private void onclose(object sender, EventArgs args) {
            Environment.Exit(0);
        }

        public SFMLRenderDriver() {
            ContextSettings contextSettings = new ContextSettings();
            contextSettings.DepthBits = 32;
            _window = new RenderWindow(new VideoMode(640, 480), "Game", Styles.Titlebar | Styles.Close, contextSettings);
            _spriteMaps = new Dictionary<string, Sprite>();
            _textMaps = new Dictionary<string, Text>();
            _font = new Font(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "/arial.ttf");
            // Make it the active window for OpenGL calls
            _window.SetVerticalSyncEnabled(true);
            _window.SetFramerateLimit(60);
            _window.SetActive();
            // Toolkit.Init();
            _window.Closed += new EventHandler(onclose);
        }
        private Sprite CacheSprite(string spriteName) {
            Texture t = new Texture(spriteName);
            t.Smooth = true;
            Sprite sprite = new Sprite(t);
            _spriteMaps.Add(spriteName, sprite);
            return sprite;
        }

        private Text CacheText(string s) {
            Text text = new Text(s, _font, 12);
            _textMaps.Add(s, text);
            return text;
        }

        public void DrawLine(Vector start, Vector end) {
            _window.Draw(new Vertex[] {
                new Vertex(new Vector2f(start.X, start.Y), Color.Black),
                new Vertex(new Vector2f(end.X, end.Y), Color.Black )
            }, PrimitiveType.Lines);
        }

        public void DrawSprite(string spriteName, Vector position, Vector scale, int rotation) {
            Sprite sprite;
            if (!_spriteMaps.TryGetValue(spriteName, out sprite)) {
                sprite = CacheSprite(spriteName);
            }

            sprite.Position = new Vector2f(position.X, position.Y);
            sprite.Scale = new Vector2f(scale.X, scale.Y);
            sprite.Rotation = rotation;
            _window.Draw(sprite);
        }

        public void DrawSprite(string spriteName, Vector position, Vector scale) {
            DrawSprite(spriteName, position, scale, 1);
        }

        public void DrawSprite(string spriteName, Vector pos) {
            DrawSprite(spriteName, pos, new Vector(1, 1));
        }

        public void DrawText(string textToDraw, Vector pos) {
            Text text;
            if (!_textMaps.TryGetValue(textToDraw, out text)) {
                text = CacheText(textToDraw);
            }
            text.Position = new Vector2f(pos.X, pos.Y);
            text.Origin = new Vector2f(0.0f, 0.0f);
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