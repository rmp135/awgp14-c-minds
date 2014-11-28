using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interfaces;

namespace CSharpMinds.Systems {
    public interface ISystem : IUpdatable {
        void Initialise();
    }
}
