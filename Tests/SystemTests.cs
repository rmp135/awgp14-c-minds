using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds.Managers;
using CSharpMinds;
using ConsoleLibrary.Drivers;
using System.Collections.Generic;
using Tests.Mocks;
using CSharpMinds.Systems;
using Common;

namespace Tests {
    [TestClass]
    public class SystemTests {
        [TestMethod]
        public void TestGetSystemByType() {
            MockSystem mockSystem = new MockSystem();
            SystemManager.AddSystems(new List<ISystem>() { mockSystem });
            Assert.IsTrue(SystemManager.GetSystem<MockSystem>().DoWork());
        }

        [TestMethod]
        public void TestAddingTheSameSystem() {
            MockSystem system1 = new MockSystem();
            MockSystem system2 = new MockSystem();
            SystemManager.AddSystems(new List<ISystem>() { system1, system2 });
            Assert.AreEqual(system2, (SystemManager.GetSystem<MockSystem>()));
        }

        [TestMethod]
        public void TestUpdatingSystems() {
            MockSystem mockSystem = new MockSystem();
            SystemManager.AddSystems(new List<ISystem>() { mockSystem });
            SystemManager.Update(new GameTime());
            Assert.IsTrue(mockSystem.Updated);
        }
    }
}
