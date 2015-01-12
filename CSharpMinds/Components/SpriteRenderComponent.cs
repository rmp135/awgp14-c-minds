using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System;

namespace CSharpMinds.Components
{
    public class SpriteRenderComponent : Component, IDrawable
    {
        private RenderSystem _renderSystem;
        private TransformComponent _transComp;
        private String _spriteName;

        public String SpriteName {
            set { _spriteName = value; }
            get { return _spriteName; }
        }
        public SpriteRenderComponent() : base("SpriteRenderComponent") { }
        public SpriteRenderComponent(String spriteName)
            : this() {
            _spriteName = spriteName;
        }

        public override void Initialise() {
            _renderSystem = SystemManager.GetSystem<RenderSystem>() as RenderSystem;
            _transComp = Owner.GetComponent<TransformComponent>() as TransformComponent;
        }

        public void Draw() {
            _renderSystem.DrawSprite(_spriteName, _transComp.Position, _transComp.Scale, _transComp.Rotation);
        }
    }
}