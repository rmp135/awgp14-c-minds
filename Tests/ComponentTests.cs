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
        private TransformComponent mockTransformComp;

        [TestInitialize]
        public void Setup() {
            mockTransformComp = new TransformComponent();
            go = new GameObject("go");
        }

        [TestMethod]
        public void TestInitPosRotScale() {
            Assert.AreEqual(0, mockTransformComp.Position.X);
            Assert.AreEqual(new Vector(1,1,1), mockTransformComp.Scale);
            Assert.AreEqual(0, mockTransformComp.Rotation);
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
            mockTransformComp.Position = new Vector(20, 30);
            Assert.AreEqual(20, mockTransformComp.Position.X);
            Assert.AreEqual(30, mockTransformComp.Position.Y);
        }

        [TestMethod]
        public void TestCanScale() {
            mockTransformComp.Scale = new Vector(2.5f,2.5f);
            Assert.AreEqual(2.5f, mockTransformComp.Scale.X);
            mockTransformComp.Scale = new Vector(-2.5f,-2.5f);
            Assert.AreEqual(-2.5f, mockTransformComp.Scale.Y);
        }

        [TestMethod]
        public void TestCanRotate() {
            mockTransformComp.Rotation = 275;
            Assert.AreEqual(275, mockTransformComp.Rotation);
        }

        [TestMethod]
        public void TestRotationBoundaries() {
            mockTransformComp.Rotation = 540;
            Assert.AreEqual(180, mockTransformComp.Rotation);
            mockTransformComp.Rotation = -540;
            Assert.AreEqual(180, mockTransformComp.Rotation);
        }

        [TestMethod]
        public void TestComponentHasOwnerAdded() {
            go.AddComponent(mockTransformComp);
            Assert.AreEqual("go", mockTransformComp.Owner.Name);
        }

        [TestMethod]
        public void TestComponentHasOwnerRemoved() {
            go.AddComponent(mockTransformComp);
            go.RemoveComponent(mockTransformComp);
            Assert.AreEqual(null, mockTransformComp.Owner);
        }

        [TestMethod]
        public void TestRemovingNonExistentComponent() {
            MockUpdateComponent tc2 = new MockUpdateComponent();
            go.RemoveComponent(tc2);
            Assert.AreEqual(0, go.Components.Count);
        }

        [TestMethod]
        public void TestAddingSameComponentTwice() {
            go.AddComponent(mockTransformComp);
            go.AddComponent(mockTransformComp);
            Assert.AreEqual(1, go.Components.Count);
        }

        [TestMethod]
        public void TestGettingComponentByType() {
            go.AddComponent(mockTransformComp);
            TransformComponent t = go.GetComponent<TransformComponent>() as TransformComponent;
            Assert.AreEqual("Transform", t.Name);
        }

        [TestMethod]
        public void TestNonUpdatableComps() {
            Scene s = new Scene();
            go.AddComponent(mockTransformComp);
            s.AddGameObject(go);
            s.Update(new GameTime());
        }

        [TestMethod]
        public void DisabledCompsDoNotUpdate() {
            Scene s = new Scene();
            MockUpdateComponent up = new MockUpdateComponent();
            go.AddComponent(up);
            mockTransformComp.Enabled = false;
            Assert.IsFalse(up.Updated);
        }

        [TestMethod]
        public void DisabledCompsDoNotDraw() {
            Scene s = new Scene();
            MockDrawComponent dc = new MockDrawComponent();
            go.AddComponent(dc);
            mockTransformComp.Enabled = false;
            Assert.AreEqual(false, dc.DrawCalled);
        }

        [TestMethod]
        public void ChildObjectsFollowParent() {
            go.AddComponent(mockTransformComp);
            GameObject child = new GameObject();
            TransformComponent childTrans = new TransformComponent();
            child.AddComponent(childTrans);

            go.AddChild(child);

            mockTransformComp.Position = new Vector(1, 0, 0);
            childTrans.Position = new Vector(1, 1, 0);

            Assert.AreEqual(new Vector(2, 1), childTrans.Position);
        }
    }
}