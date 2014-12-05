using CSharpMinds;
using CSharpMinds.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mocks;
using Common;

namespace Tests
{
    [TestClass]
    public class SceneTests
    {
        private Scene scene;
        private GameObject go;

        [TestInitialize]
        public void Setup() {
            scene = new Scene();
            go = new GameObject();
        }

        [TestMethod]
        public void TestGameObjectsAddToScene() {
            TransformComponent tc = new TransformComponent();
            go.AddComponent(tc);
            scene.AddGameObject(go);
            scene.Update(new GameTime());
            Assert.AreEqual(1, scene.GameObjects.Count);
        }

        [TestMethod]
        public void TestGameObjectsRemoveFromScene() {
            TransformComponent tc = new TransformComponent();
            go.AddComponent(tc);
            scene.AddGameObject(go);
            scene.RemoveGameObject(go);
            Assert.AreEqual(0, scene.GameObjects.Count);
        }

        [TestMethod]
        public void TestRemoveChildGameObjectsFromScene() {
            GameObject child = new GameObject();
            child.Parent = go;
            child.AddComponent(new TransformComponent());
            scene.AddGameObject(go);
            scene.Update(new GameTime());
            Assert.AreEqual(1, scene.GameObjects.Count);

            scene.RemoveGameObject(go);
            scene.Update(new GameTime());
            Assert.AreEqual(0, scene.GameObjects.Count);
        }

        [TestMethod]
        public void TestAddChildGameObjectsFromScene() {
            GameObject child = new GameObject();
            child.Parent = go;
            child.AddComponent(new TransformComponent());
            scene.AddGameObject(go);
            scene.Update(new GameTime());
            Assert.AreEqual(1, scene.GameObjects.Count);

            scene.RemoveGameObject(go);
            scene.Update(new GameTime());
            Assert.AreEqual(0, scene.GameObjects.Count);
        }

        [TestMethod]
        public void TestSceneUpdates() {

            GameObject go = new GameObject();
            MockUpdateComponent tc = new MockUpdateComponent();
            go.AddComponent(tc);
            scene.AddGameObject(go);

            scene.Update(new GameTime());
            Assert.IsTrue((go.GetComponentByName("UpdatingComp") as MockUpdateComponent).Updated);
        }

        [TestMethod]
        public void TestFindGameObjectByName() {
            go.Name = "test";
            scene.AddGameObject(go);
            scene.Update(new GameTime());
            Assert.AreEqual(scene.FindGameObjectByName("test"), go);
        }

        [TestMethod]
        public void TestSceneDestroys() {
            scene.Destroy();
            Assert.IsNull(scene.GameObjects);
        }
        [TestMethod]
        public void TestSceneUpdatesChildComp() {
            GameObject child = new GameObject();
            child.AddComponent(new MockUpdateComponent());
            go.AddChild(child);
            scene.AddGameObject(go);
            scene.Update(new GameTime());
            Assert.IsTrue(child.GetComponent<MockUpdateComponent>().Updated);
        }
    }
}