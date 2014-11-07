using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;

namespace ConsoleLibrary.Drivers
{
    public class ConsoleRenderDriver : IRenderDriver
    {
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
    }
}
