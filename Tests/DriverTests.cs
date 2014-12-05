using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mocks;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System.Collections.Generic;
using Common;

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
            SystemManager.Update(new GameTime());
            Assert.IsTrue(mockInputDriver.Updated);
        }

        [TestMethod]
        public void TestInputActions() {
            CSharpMinds.Systems.InputSystem input = new CSharpMinds.Systems.InputSystem(mockInputDriver);
            input.setBinding("UP", Keys.keyboard.A);
            SystemManager.AddSystems(new List<ISystem> { input });
            Assert.IsTrue(input.isActionDown("UP"));
            Assert.IsTrue(input.isActionPressed("UP"));
            Assert.IsFalse(input.isActionDown("DOWN"));
            Assert.IsFalse(input.isActionPressed("DOWN"));
        }
    }
}
