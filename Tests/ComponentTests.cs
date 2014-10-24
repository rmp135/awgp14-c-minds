using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds.Components;
using CSharpMinds;

namespace Tests
{
    [TestClass]
    public class ComponentTests
    {
        GameObject go;
        TransformComponent tc;

        [TestInitialize]
        public void Setup()
        {
            tc = new TransformComponent();
            go = new GameObject("go");
        }

        [TestMethod]
        public void TestInitPosRotScale()
        {
            Assert.AreEqual(0, tc.Position.X);
            Assert.AreEqual(1.0, tc.Scale);
            Assert.AreEqual(0, tc.Rotation);
        }

        [TestMethod]
        public void TestCanMovePosition()
        {
            tc.Position.X = 20;
            tc.Position.Y = 30;
            Assert.AreEqual(20, tc.Position.X);
            Assert.AreEqual(30, tc.Position.Y);
        }

        [TestMethod]
        public void TestCanScale()
        {
            tc.Scale = 2.5f;
            Assert.AreEqual(2.5f, tc.Scale);
            tc.Scale = -2.5f;
            Assert.AreEqual(-2.5f, tc.Scale);
        }

        [TestMethod]
        public void TestCanRotate()
        {
            tc.Rotation = 275;
            Assert.AreEqual(275, tc.Rotation);
        }

        [TestMethod]
        public void TestRotationBoundaries()
        {
            tc.Rotation = 540;
            Assert.AreEqual(180, tc.Rotation);
            tc.Rotation = -540;
            Assert.AreEqual(180, tc.Rotation);
        }

        [TestMethod]
        public void TestComponentHasOwnerAdded() {
            go.AddComponent(tc);
            Assert.AreEqual("go", tc.Owner.Name);
        }

        [TestMethod]
        public void TestComponentHasOwnerRemoved() {
            go.AddComponent(tc);
            go.RemoveComponent(tc);
            Assert.AreEqual(null, tc.Owner);
        }

        [TestMethod]
        public void TestRemovingNonExistentComponent() {
            UpdatingComponent tc2 = new UpdatingComponent("tc2");
            go.RemoveComponent(tc2);
            Assert.AreEqual(0, go.Components.Count);
        }

        [TestMethod]
        public void TestAddingSameComponentTwice() {
            go.AddComponent(tc);
            go.AddComponent(tc);
            Assert.AreEqual(1, go.Components.Count);
        }
    }
}
