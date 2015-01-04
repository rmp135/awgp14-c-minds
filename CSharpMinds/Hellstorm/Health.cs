using CSharpMinds.Components;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpMinds.Hellstorm
{
    class HealthComponent : Component, IDrawable
    {
        private RenderSystem _render;
        private int _health;

        public HealthComponent()
        {
            Health = 5;
        }
        public int Health
        {
            get { return _health; }
            set { _health = Common.MathHelper.Clamp(0, 5, value); }
        }

        public override void Initialise()
        {
            _render = SystemManager.GetSystem<RenderSystem>();
        }

        public void Draw()
        {
            bool[] _t = new bool[5];
            for (int i = 0; i < Health; i++)
            {
                _t[i] = true;
            }
            for (int i = 0; i < _t.Length; i++)
            {
                if (_t[i] == true)
                {
                    _render.DrawSprite("Hellstorm\\Resources\\bolt_gold.png", new Common.Vector(i*20, 0));
                }
                else
                {
                    _render.DrawSprite("Hellstorm\\Resources\\bold_silver.png", new Common.Vector(i*20, 0));
                }
            }
        }
    }
}
