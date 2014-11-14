using Common;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    internal class FrameRateComponent : TextRenderComponent, IUpdatable
    {
        private GameTime _gameTime;

        public override void Draw() {
            float framerate = (_gameTime.DeltaTime == 0) ? 0 : 1000 / _gameTime.DeltaTime;
            _renderSystem.DrawText(framerate.ToString(), new Vector());
        }

        public void Update(GameTime gameTime) {
            _gameTime = gameTime;
        }
    }
}