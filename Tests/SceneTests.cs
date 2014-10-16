using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;
using CSharpMinds.Interfaces;
namespace Tests {
    [TestClass]
    public class SceneTests {

        [TestMethod]
        public void TestGameObjectsAddToScene() {
            Scene scene = new Scene();
            scene.GOFactory.Build();
            Assert.AreEqual(1, scene.CompManager.Components.Count);
        }

        [TestMethod]
        public void TestSceneUpdates() {
            Scene scene = new Scene();
            IGameObject go = scene.GOFactory.Build();
            TestComponent tc = new TestComponent("test");
            go.AddComponent(tc);
            scene.CompManager.AddComponent(tc);
            scene.Update();
            Assert.AreEqual(1, (go.GetComponentByName("test") as TestComponent).TestInt);
        }

    }
}
