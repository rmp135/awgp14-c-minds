using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;

namespace Tests {
    [TestClass]
    public class GameObjectHierarchyTests {
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
}
