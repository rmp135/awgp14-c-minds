﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Systems;
using CSharpMinds.Managers;
using CSharpMinds.Interfaces;

namespace Tests.Mocks
{
    class MockInputSystem : ISystem
    {
        public MockInputDriver Driver;
        public bool Updated;
        public void Initialise() {
            
        }

        public MockInputSystem(MockInputDriver driver) {
            Driver = driver;
        }


        public void Update(CSharpMinds.GameTime gameTime) {
            Updated = true;
        }
    }
}
