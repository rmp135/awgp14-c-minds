using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Tests {

    [TestClass]
    public class BasicTests {
        GameObject go;
        TestComponent c;

        [TestInitialize]
        public void Setup() {
            go = new GameObject("go");
            c = new TestComponent("comp");
        }

        [TestMethod]
        public void TestCanGetComponentByName() {
            go.AddComponent(c);
            IComponent s = go.GetComponentByName("comp");
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
            TestComponent s = go.GetComponentByName("comp") as TestComponent;
            Assert.AreEqual(0, s.TestInt);
        }

    }
}
