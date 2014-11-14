using Common;
using Common.Interfaces;
using System;

namespace ConsoleLibrary.Drivers
{
    public class ConsoleRenderDriver : IRenderDriver
    {
        public void DrawSprite(string text, Vector pos, Vector scale) {
        }

        public void DrawSprite(String spriteName, Vector position) {
        }

        public void DrawText(string text, Vector pos) {
            Console.WriteLine(text);
        }

        public void PreRender() {
            Console.Clear();
        }

        public void PostRender() {
        }

        public void DrawLine(Vector start, Vector end) {
            throw new NotImplementedException();
        }

        public void DrawSprite(string spriteName, Vector pos, Vector scale, int rotation) {
            throw new NotImplementedException();
        }
    }
}