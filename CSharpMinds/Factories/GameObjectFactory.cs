using CSharpMinds.Exceptions;
using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;

namespace CSharpMinds.Factories
{
    public static class GameObjectFactory
    {
        public static GameObject Build(string name, List<IComponent> components) {
            GameObject go = new GameObject(name);
            foreach (IComponent comp in components) {
                comp.Owner = go;
                go.AddComponent(comp);
            }
            foreach (IComponent comp in components) {
                try {
                    comp.Initialise();
                }
                catch (ComponentNotFoundException e) {
                    Console.WriteLine(comp + " is missing a " + e.ComponentName + " component dependancy.");
                    comp.Enabled = false;
                }
                catch (SystemNotFoundException e) {
                    Console.WriteLine(comp + " is missing a " + e.SystemName + " system dependancy.");
                    comp.Enabled = false;
                }
            }
            return go;
        }

        public static GameObject Build(List<IComponent> components) {
            return Build(Guid.NewGuid().ToString(), components);
        }
    }
}