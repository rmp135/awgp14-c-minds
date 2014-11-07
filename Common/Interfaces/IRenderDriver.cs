using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRenderDriver
    {
        void DrawSprite(string spriteName, Vector position);
        void DrawText(string text, Vector pos);
        void PreRender();
        void PostRender();
    }
}
