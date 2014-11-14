using Common;
using CSharpMinds;
using CSharpMinds.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mocks;

namespace Tests
{
    [TestClass]
    public class ComponentTests
    {
        private GameObject go;
        private TransformComponent tc;

        [TestInitialize]
        public void Setup() {
            tc = new TransformComponent();
            go = new GameObject("go");
        }

        [TestMethod]
        public void TestInitPosRotScale() {
            Assert.AreEqual(0, tc.Position.X);
            Assert.AreEqual(1.0, tc.Scale);
            Assert.AreEqual(0, tc.Rotation);
        }

        [TestMethod]
        public void TestSetChildComponents() {
            GameObject go2 = new GameObject();
            go2.AddComponent(new MockDrawComponent());
            go.AddChild(go2);
            Assert.AreEqual(1, go.ChildComponents.Count);
            Assert.AreEqual(0, go.Components.Count);
        }

        [TestMethod]
        public void TestCanMovePosition() {
            tc.Position = new Vector(20, 30);
            Assert.AreEqual(20, tc.Position.X);
            Assert.AreEqual(30, tc.Position.Y);
        }

        [TestMethod]
        public void TestCanScale() {
            tc.Scale = 2.5f;
            Assert.AreEqual(2.5f, tc.Scale);
            tc.Scale = -2.5f;
            Assert.AreEqual(-2.5f, tc.Scale);
        }

        [TestMethod]
        public void TestCanRotate() {
            tc.Rotation = 275;
            Assert.AreEqual(275, tc.Rotation);
        }

        [TestMethod]
        public void TestRotationBoundaries() {
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
            MockUpdateComponent tc2 = new MockUpdateComponent();
            go.RemoveComponent(tc2);
            Assert.AreEqual(0, go.Components.Count);
        }

        [TestMethod]
        public void TestAddingSameComponentTwice() {
            go.AddComponent(tc);
            go.AddComponent(tc);
            Assert.AreEqual(1, go.Components.Count);
        }

        [TestMethod]
        public void TestGettingComponentByType() {
            go.AddComponent(tc);
            TransformComponent t = go.GetComponent<TransformComponent>() as TransformComponent;
            Assert.AreEqual("Transform", t.Name);
        }

        [TestMethod]
        public void TestNonUpdatableComps() {
            Scene s = new Scene();
            go.AddComponent(tc);
            s.AddGameObject(go);
            s.Update(new GameTime());
        }

        [TestMethod]
        public void DisabledCompsDoNotUpdate() {
            Scene s = new Scene();
            MockUpdateComponent up = new MockUpdateComponent();
            go.AddComponent(up);
            tc.Enabled = false;
            Assert.IsFalse(up.Updated);
        }

        [TestMethod]
        public void DisabledCompsDoNotDraw() {
            Scene s = new Scene();
            MockDrawComponent dc = new MockDrawComponent();
            go.AddComponent(dc);
            tc.Enabled = false;
            Assert.AreEqual(false, dc.DrawCalled);
        }

        [TestMethod]
        public void ChildObjectsFollowParent() {
            go.AddComponent(tc);
            GameObject child = new GameObject();
            TransformComponent childTrans = new TransformComponent();
            child.AddComponent(childTrans);

            go.AddChild(child);

            tc.Position = new Vector(1, 0, 0);
            childTrans.Position = new Vector(1, 1, 0);

            Assert.AreEqual(new Vector(2, 1), childTrans.Position);
        }
    }
}