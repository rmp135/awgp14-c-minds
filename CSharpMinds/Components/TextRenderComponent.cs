using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;

namespace CSharpMinds.Components
{
    public class TextRenderComponent : Component, IDrawable
    {
        protected RenderSystem _renderSystem;
        protected TransformComponent _transComp;
        private string _text;

        public TextRenderComponent()
            : base("TextRenderer") {
                _text = "";
        }
        public TextRenderComponent(string text)
            : this()
        {
            _text = text;
        }

        public override void Initialise() {
            _renderSystem = SystemManager.GetSystem<RenderSystem>() as RenderSystem;
            _transComp = Owner.GetComponent<TransformComponent>() as TransformComponent;
        }

        public virtual void Draw() {
            _renderSystem.DrawText(_text, 30, _transComp.Position);
        }
    }
}