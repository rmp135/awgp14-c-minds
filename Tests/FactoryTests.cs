using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds.Factories;
using CSharpMinds;
using CSharpMinds.Managers;

namespace Tests {
    [TestClass]
    public class FactoryTests {
        [TestMethod]
        public void TestGameObjectFactory() {
            
            BasicGameObjectFactory gof = new BasicGameObjectFactory(new ComponentManager());
            GameObject g = gof.Build() as GameObject;

            Assert.AreEqual("Transform", g.FindByName("Transform").Name);
        }
    }
}
