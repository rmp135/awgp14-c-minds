using CSharpMinds.Components;
using CSharpMinds.Interfaces;

namespace Tests.Components
{
    internal class MockDrawComponent : Component, IDrawable
    {
        private bool _drawCalled;

        public bool DrawCalled {
            get { return _drawCalled; }
        }

        public void Draw() {
            _drawCalled = true;
        }
    }
}