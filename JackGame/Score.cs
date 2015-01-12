using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Components;
using CSharpMinds.Interfaces;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using CSharpMinds.Resources;

namespace JackGame
{
    class ScoreComponent : Component, IDrawable
    {
        private RenderSystem _render;
        private int score;
        private ImageResource resource;

        public ScoreComponent(ImageResource resource)
        {
            Score = 10;
            this.resource = resource;
        }
        public int Score
        {
            get { return score; }
            set { score = Common.MathHelper.Clamp(0, 10, value); }
        }

        public override void Initialise()
        {
            _render = SystemManager.GetSystem<RenderSystem>();
        }

        public void Draw()
        {
            bool[] _t = new bool[10];
            for (int i = 0; i < score; i++)
            {
                _t[i] = true;
            }
            for (int i = 0; i < _t.Length; i++)
            {
                if (_t[i] == true)
                {
                    _render.DrawSprite(resource.FilePath, new Common.Vector(i*20, 0));
                }
            }
        }
    }
}
