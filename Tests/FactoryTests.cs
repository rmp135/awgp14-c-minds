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
        public void TestGOFactoryAddsComponent() {

            GameObject g = GameObjectFactory.Build(new List<IComponent>() { new TransformComponent() });

            Assert.AreEqual("Transform", g.GetComponent<TransformComponent>().Name);
        }

        [TestMethod]
        public void TestGOSetsComponentOwner() {

            TransformComponent tc = new TransformComponent();

            GameObject g = GameObjectFactory.Build(new List<IComponent>() { tc });

            Assert.AreEqual(g, tc.Owner);
        }

        [TestMethod]
        public void TestGOSetsCompThatReliesOnAnotherComps() {

            TransformComponent tc = new TransformComponent();
            TextRenderComponent trc = new TextRenderComponent();

            GameObject g = GameObjectFactory.Build(new List<IComponent>() { tc, trc });

            Assert.AreEqual(g, tc.Owner);
            Assert.AreEqual(g, trc.Owner);
        }
    }
}
