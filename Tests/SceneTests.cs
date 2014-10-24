using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
namespace Tests {
    [TestClass]
    public class SceneTests {

        [TestMethod]
        public void TestGameObjectsAddToScene() {
            Scene scene = new Scene();
            GameObject go = new GameObject("go");
            TransformComponent tc = new TransformComponent();
            go.AddComponent(tc);
            scene.AddGameObject(go);
            Assert.AreEqual(1, scene.CompManager.Components.Count);
        }

        [TestMethod]
        public void TestSceneUpdates() {
            Scene scene = new Scene();

            GameObject go = new GameObject("go");
            UpdatingComponent tc = new UpdatingComponent("test");
            go.AddComponent(tc);
            scene.AddGameObject(go);

            scene.Update();
            Assert.AreEqual(1, (go.FindByName("test") as UpdatingComponent).TestInt);
        }

    }
}
