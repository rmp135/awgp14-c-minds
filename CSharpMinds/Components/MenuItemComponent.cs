using Common.Interfaces;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Components
{
    class MenuItemComponent : TextRenderComponent
    {
        private bool _active;
        private String _label;

        public MenuItemComponent(String label)
            : base()
        {
            _label = label;
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public override void Draw()
        {
            _renderSystem.DrawText(_label, _active ? 50 : 30, _transComp.Position);
        }
    }
}
