using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Systems
{
    public class ConsoleRenderDriver : IRenderDriver
    {
        public void DrawSprite(Vector position) {
            throw new NotImplementedException();
        }

        public void DrawText(string text) {
            Console.WriteLine(text);
        }

        public void ClearBuffer() {
            Console.Clear();
        }
    }
}
