﻿using CSharpMinds.Systems;
using System;
﻿using CSharpMinds.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Managers {
    public static class SystemManager {

        static List<ISystem> systems;

        public static void AddSystem(ISystem system) {
            if (systems == null) { systems = new List<ISystem>(); }
            ISystem alreadyImplemented = systems.Find(p => p.GetType() == system.GetType());
            if (alreadyImplemented != null) {
                systems.Remove(alreadyImplemented);
            }
            systems.Add(system);
        }
        public static T GetSystem<T>() {
            if (systems == null) { systems = new List<ISystem>(); }
            return (T)systems.Find(p => p.GetType() == typeof(T));
        }

        public static void Update(GameTime gameTime) {
            foreach (ISystem system in systems) {
                if (system is IUpdatable) {
                    ((IUpdatable)system).Update(gameTime);
                }
            }
        }
    }
}
