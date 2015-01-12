using CSharpMinds.Exceptions;
using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using CSharpMinds;

namespace CSharpMinds.Factories
{
    public static class GameObjectFactory
    {

        public static GameObject BuildFromXML(string xmlFile) {
            GameObject go;
            try {
                go = (GameObject)XMLSerialisation.ConstructFromXml<GameObject>(xmlFile);
            }
            catch (System.IO.FileNotFoundException e ) {
                Console.WriteLine("The file " + xmlFile + " could not be found. A placeholder GameObject has been created.");
                go = GameObjectFactory.Build(new List<IComponent>());
            }
            go.Initialise();
            return go;
        }

        public static GameObject Build(string name, List<IComponent> components) {
            GameObject go = new GameObject(name);
            foreach (IComponent comp in components) {
                go.AddComponent(comp);
            }
            go.Initialise();
            return go;
        }

        public static GameObject Build(List<IComponent> components) {
            return Build(Guid.NewGuid().ToString(), components);
        }
    }
}