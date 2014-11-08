using Common;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    internal class FrameRateComponent : TextRenderComponent, IUpdatable
    {
        private GameTime _gameTime;

        public override void Draw() {
            _renderSystem.DrawText((1000 / _gameTime.DeltaTime).ToString(), new Vector());
        }

        public void Update(GameTime gameTime) {
            _gameTime = gameTime;
        }
    }
}