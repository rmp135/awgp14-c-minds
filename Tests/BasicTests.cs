using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;

namespace CSharpMinds.Tests {

    [TestClass]
    public class BasicTests {
        GameObject go;
        UpdatingComponent c;

        [TestInitialize]
        public void Setup() {
            go = new GameObject("go");
            c = new UpdatingComponent("comp");
        }

        [TestMethod]
        public void TestCanGetComponentByName() {
            go.AddComponent(c);
            IComponent s = go.FindByName("comp");
            Assert.AreEqual("comp", s.Name);
        }

        [TestMethod]
        public void TestComponentsUpdate() {
            go.AddComponent(c);
            c.Update();
            Assert.AreEqual(1, c.TestInt);
        }

        [TestMethod]
        public void TestCastingComponents() {
            go.AddComponent(c);
            UpdatingComponent s = go.FindByName("comp") as UpdatingComponent;
            Assert.AreEqual(0, s.TestInt);
        }

    }
}
