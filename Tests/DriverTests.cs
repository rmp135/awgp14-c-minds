using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mocks;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DriverTests
    {
        MockInputDriver mockInputDriver;
        MockInputSystem mockInputSystem;
        
        [TestInitialize]
        public void Setup() {
            mockInputDriver = new MockInputDriver();
            mockInputSystem = new MockInputSystem(mockInputDriver);
        }

        [TestMethod]
        public void TestAddingDriver() {
            SystemManager.AddSystems(new List<ISystem>() { mockInputSystem });
            SystemManager.GetSystem<MockInputSystem>();
        }

        [TestMethod]
        public void TestUpdatingDriver() {
            SystemManager.AddSystems(new List<ISystem>() { mockInputSystem });
            SystemManager.Update(new CSharpMinds.GameTime());
            Assert.IsTrue(mockInputDriver.Updated);
        }
    }
}
