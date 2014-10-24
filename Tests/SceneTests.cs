using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
namespace Tests {
    [TestClass]
    public class SceneTests {

        Scene scene;
        GameObject go;

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
            Assert.AreEqual(1, scene.CompManager.Components.Count);
        }

        [TestMethod]
        public void TestGameObjectsRemoveFromScene() {
            TransformComponent tc = new TransformComponent();
            go.AddComponent(tc);
            scene.AddGameObject(go);
            scene.RemoveGameObject(go);
            Assert.AreEqual(0, scene.CompManager.Components.Count);
        }

        [TestMethod]
        public void TestRemoveChildGameObjectsFromScene() {
            GameObject child = new GameObject();
            child.Parent = go;
            child.AddComponent(new TransformComponent());
            scene.AddGameObject(go);
            Assert.AreEqual(1, scene.CompManager.Components.Count);

            scene.RemoveGameObject(go);
            Assert.AreEqual(0, scene.CompManager.Components.Count);

        }

        [TestMethod]
        public void TestAddChildGameObjectsFromScene() {
            GameObject child = new GameObject();
            child.Parent = go;
            child.AddComponent(new TransformComponent());
            scene.AddGameObject(go);
            Assert.AreEqual(1, scene.CompManager.Components.Count);

            scene.RemoveGameObject(go);
            Assert.AreEqual(0, scene.CompManager.Components.Count);

        }

        [TestMethod]
        public void TestSceneUpdates() {
            Scene scene = new Scene();

            GameObject go = new GameObject();
            UpdatingComponent tc = new UpdatingComponent("test");
            go.AddComponent(tc);
            scene.AddGameObject(go);

            scene.Update(new GameTime());
            Assert.AreEqual(1, (go.GetComponentByName("test") as UpdatingComponent).TestInt);
        }

    }
}
