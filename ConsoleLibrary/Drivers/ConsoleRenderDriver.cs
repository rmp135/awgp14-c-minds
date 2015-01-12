using Common;
using Common.Interfaces;
using System;

namespace ConsoleLibrary.Drivers
{
    public class ConsoleRenderDriver : IRenderDriver
    {
        public void DrawSprite(string spriteName, Vector pos, Vector scale) {
            DrawSprite(spriteName, pos);
        }

        public void DrawSprite(string spriteName, Vector position) {
            Console.WriteLine(spriteName + " at position " + position);
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
            
        }

        public void DrawSprite(string spriteName, Vector pos, Vector scale, int rotation) {
            DrawSprite(spriteName, pos);
        }


        public void DrawText(string text, int size, Vector pos)
        {
            DrawText(text, pos);
        }
    }
}