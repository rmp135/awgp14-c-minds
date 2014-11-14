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

        public void DrawSprite(string spriteName, Vector position, Vector scale, int rotation) {
            _driver.DrawSprite(spriteName, position, scale, rotation);
        }

        public void DrawSprite(string spritename, Vector position, Vector scale) {
            _driver.DrawSprite(spritename, position, scale);
        }

        public void DrawText(string text, Vector pos) {
            _driver.DrawText(text, pos);
        }

        public void DrawLine(Vector start, Vector end) {
            _driver.DrawLine(start, end);
        }

        public void PreRender() {
            _driver.PreRender();
        }

        public void PostRender() {
            _driver.PostRender();
        }
    }
}