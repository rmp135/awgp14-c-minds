﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces
{
    public interface IRenderDriver
    {
        void DrawSprite(Vector position);
        void DrawText(string text);
        void ClearBuffer();
    }
}
