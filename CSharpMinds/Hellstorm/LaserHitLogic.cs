using Common.Interfaces;
using CSharpMinds.Components;
using CSharpMinds.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Hellstorm
{
    class LaserHitLogic : Component, IUpdatable
    {
        double _start;
        public void Update(Common.GameTime gameTime)
        {
            if (_start == null)
                _start = gameTime.TotalTime;
            if (gameTime.TotalTime > _start + 100)
            {
                SceneManager.RemoveGameObjectFromScene(Owner);
            }
        }
    }
}
