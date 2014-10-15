using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;

namespace CSharpMinds.Tests {

    [TestClass]
    public class GameObjectHierarchyTest {
        GameObject go, go2, go3;

        [TestInitialize]
        public void Setup() {
            go = new GameObject("go");
            go2 = new GameObject("go2");
            go3 = new GameObject("go3");
        }
      
        [TestMethod]
        public void TestGameObjectParentSet() {
            go2.Parent = go;
            Assert.AreEqual("go", go2.Parent.Name);
        }

        [TestMethod]
        public void TestGameObjectChildrenSet() {
            go2.Parent = go;
            go3.Parent = go;
            Assert.AreEqual(go.Children.Count, 2);
        }

        public void TestAddChildren() {
            go.AddChild(go2);
            Assert.AreEqual("go", go2.Parent.Name);
            Assert.AreEqual(1, go.Children.Count);
            Assert.AreEqual("go2", go.Children[0]);
        }

        [TestMethod]
        public void TestRemoveChildren() {
            go.AddChild(go2);
            go.AddChild(go3);
            go.RemoveChild(go2);
            Assert.AreEqual(null, go2.Parent);
            Assert.AreEqual(go.Children.Count, 1);
            Assert.AreEqual("go3", go.Children[0].Name);
        }

        [TestMethod]
        public void TestSetParentNull() {
            go.AddChild(go2);
            go2.Parent = null;
            Assert.AreEqual(null, go2.Parent);
            Assert.AreEqual(0, go.Children.Count);
        }

    }

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
            Component s = go.GetComponentByName("comp");
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
