using Common;
using Common.Interfaces;

namespace CSharpMinds.Systems
{
    public class RenderSystem : ISystem
    {
        private IRenderDriver _driver;

        public RenderSystem(IRenderDriver driver) {
            _driver = driver;
        }

        public void DrawSprite(string spriteName, Vector position) {
            _driver.DrawSprite(spriteName, position);
        }

        public void DrawText(string text, Vector pos) {
            _driver.DrawText(text, pos);
        }

        public void PreRender() {
            _driver.PreRender();
        }

        public void PostRender() {
            _driver.PostRender();
        }
    }
}