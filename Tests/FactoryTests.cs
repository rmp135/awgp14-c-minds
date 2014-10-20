using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds.Factories;
using CSharpMinds;
using CSharpMinds.Managers;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;

namespace Tests {
    [TestClass]
    public class FactoryTests {
        [TestMethod]
        public void TestGameObjectFactory() {

            GameObject g = GameObjectFactory.Build(new List<IComponent>() {new TransformComponent() });

            Assert.AreEqual("Transform", g.GetComponent<TransformComponent>().Name);
        }
    }
}
