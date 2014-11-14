using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Common.Interfaces
{
    public interface IKeyboardDriver
    {
        bool isKeyDown(Keys.keyboard key);
        bool isKeyPressed(Keys.keyboard key);
        void Initialise();
    }
}
