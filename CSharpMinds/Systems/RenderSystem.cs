using Common.Interfaces;
using CSharpMinds.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CSharpMinds.Systems
{
    public class RenderSystem : ISystem, IUpdatable
    {

        IRenderDriver _driver;
        public RenderSystem(IRenderDriver driver) {
            _driver = driver;
        }
        public void DrawSprite(string spriteName, Vector position)
        {
            _driver.DrawSprite(spriteName, position);
        }

        public void DrawText(string text, Vector pos)
        {
            _driver.DrawText(text, pos);
        }

        public void PreRender() {
            _driver.PreRender();
        }
        public void PostRender() {
            _driver.PostRender();
        }

        public void Update(GameTime gameTime) {
      //      _driver.Render();
        }
    }
}
