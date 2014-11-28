using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Components
{
    internal class SpriteLabelRenderComponent : TextRenderComponent
    {
        public override void Draw() {
            if(Owner != null)
                _renderSystem.DrawText(Owner.Name, new Vector(_transComp.Position.X, _transComp.Position.Y - 15));
        }
    }
}