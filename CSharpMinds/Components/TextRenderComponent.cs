using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Systems;
using CSharpMinds.Managers;

namespace CSharpMinds.Components
{
    public class TextRenderComponent : Component, IDrawable, IUpdatable
    {
        RenderSystem _renderSystem;
        TransformComponent _transComp;
        GameTime _gt;
        public TextRenderComponent() :base ("TextRenderer") { }

        public override void Initialise() {
            _renderSystem = SystemManager.GetSystem<RenderSystem>() as RenderSystem;
            _transComp = Owner.GetComponent<TransformComponent>() as TransformComponent;
        }

        public void Update(GameTime gameTime) {
            _gt = gameTime;
        }

        public void Draw() {
            _renderSystem.DrawText(_transComp.Position.ToString(), _transComp.Position);
        }
    }
}
