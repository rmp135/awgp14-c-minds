using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds.Systems;
using CSharpMinds.Managers;
using CSharpMinds;

namespace Tests {
    [TestClass]
    public class SystemTests {
        [TestMethod]
        [ExpectedException(typeof(System.NotImplementedException))]
        public void TestGetSystemByType() {
            AudioSystem ad = new AudioSystem(new TestAudioDriver());
            SystemManager.AddSystem(ad);
            (SystemManager.GetSystem<AudioSystem>() as AudioSystem).Play("sd");
        }

        [TestMethod]
        public void TestAddingTheSameSystem() {
            AudioSystem ad = new AudioSystem(new TestAudioDriver());
            AudioSystem ad2 = new AudioSystem(new TestAudioDriver());
            SystemManager.AddSystem(ad);
            SystemManager.AddSystem(ad2);
            Assert.AreEqual(ad2, (SystemManager.GetSystem<AudioSystem>()));
        }

        [TestMethod]
        public void TestNoneUpdatingSystems() {
            RenderSystem cr = new RenderSystem(new ConsoleRenderDriver());
            SystemManager.AddSystem(cr);
            SystemManager.Update(new GameTime());
        }
    }
}
