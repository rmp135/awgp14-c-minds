using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System;

namespace CSharpMinds.Components
{
    internal class SpriteRenderComponent : Component, IDrawable
    {
        private RenderSystem _renderSystem;
        private TransformComponent _transComp;
        private String _spriteName;

        public SpriteRenderComponent(String spriteName)
            : base("SpriteRenderer") {
            _spriteName = spriteName;
        }

        public override void Initialise() {
            _renderSystem = SystemManager.GetSystem<RenderSystem>() as RenderSystem;
            _transComp = Owner.GetComponent<TransformComponent>() as TransformComponent;
        }

        public void Draw() {
            _renderSystem.DrawSprite(_spriteName, _transComp.Position);
        }
    }
}