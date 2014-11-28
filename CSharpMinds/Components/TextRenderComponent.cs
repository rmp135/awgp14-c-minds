using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;

namespace CSharpMinds.Components
{
    public class TextRenderComponent : Component, IDrawable
    {
        protected RenderSystem _renderSystem;
        protected TransformComponent _transComp;

        public TextRenderComponent()
            : base("TextRenderer") {
        }

        public override void Initialise() {
            _renderSystem = SystemManager.GetSystem<RenderSystem>() as RenderSystem;
            _transComp = Owner.GetComponent<TransformComponent>() as TransformComponent;
        }

        public virtual void Draw() {
        }
    }
}