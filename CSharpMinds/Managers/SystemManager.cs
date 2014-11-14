using CSharpMinds.Exceptions;
using CSharpMinds.Interfaces;
using CSharpMinds.Systems;
using System.Collections.Generic;

namespace CSharpMinds.Managers
{
    public static class SystemManager
    {
        private static List<ISystem> _systems;

        private static void AddSystem(ISystem system) {
            if (_systems == null) { _systems = new List<ISystem>(); }
            ISystem alreadyImplemented = _systems.Find(p => p.GetType() == system.GetType());
            if (alreadyImplemented != null) {
                _systems.Remove(alreadyImplemented);
            }
            _systems.Add(system);
        }

        public static void AddSystems(List<ISystem> systems) {
            foreach (ISystem system in systems) {
                AddSystem(system);
            }
            foreach (ISystem system in _systems) {
                system.Initialise();
            }
        }

        public static T GetSystem<T>() {
            if (_systems == null) { throw new SystemNotFoundException(typeof(T).ToString()); }
            T ret = (T)_systems.Find(p => p.GetType() == typeof(T));
            if (ret == null) { throw new SystemNotFoundException(typeof(T).ToString()); }
            return ret;
        }

        public static void Update(GameTime gameTime) {
            foreach (ISystem system in _systems) {
                IUpdatable updatable = system as IUpdatable;
                if (updatable != null) {
                    updatable.Update(gameTime);
                }
            }
        }
    }
}