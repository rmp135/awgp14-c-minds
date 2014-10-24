using CSharpMinds.Interfaces;
using CSharpMinds.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Systems
{
    public class RenderSystem : ISystem, IUpdatable
    {
        IRenderDriver _driver;
        public RenderSystem(IRenderDriver driver) {
            _driver = driver;
        }
        public void DrawSprite(Vector position)
        {
            _driver.DrawSprite(position);
        }

        public void DrawText(string text)
        {
            _driver.DrawText(text);
        }

        public void Update(GameTime gameTime) {
            _driver.ClearBuffer();
        }
    }
}
