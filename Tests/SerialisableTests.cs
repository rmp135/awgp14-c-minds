using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mocks;
using System.Xml.Serialization;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using System.Collections.Generic;
using Common;
using CSharpMinds;
using CSharpMinds.Systems;
using CSharpMinds.Managers;

namespace Tests
{
    [TestClass]
    public class SerialisableTests
    {
        [TestInitialize]
        public void Setup() {
        }

        [TestMethod]
        public void TestCanSerialiseGameObjectWithComps() {

            GameObject original = GameObjectFactory.Build("test", new List<IComponent>() {
                new MockReliesOnComponent(){Enabled=false},
                new MockUpdateComponent(){Enabled=false},
                new TransformComponent()
            });

            XMLSerialisation.ConstructXML(original, "test.xml");
            GameObject copy = GameObjectFactory.BuildFromXML("test.xml");

            Assert.AreEqual(original.Name, copy.Name);
            Assert.IsFalse(copy.GetComponent<MockReliesOnComponent>().Enabled);
            Assert.IsFalse(copy.GetComponent<MockUpdateComponent>().Enabled);
        }

        [TestMethod]
        public void TestCanSerialiseGoWithChildren() {
            GameObject original = GameObjectFactory.Build("test", new List<IComponent>());
            GameObject child = GameObjectFactory.Build("child", new List<IComponent>());
            original.AddChild(child);

            XMLSerialisation.ConstructXML(original, "test.xml");
            GameObject copy = GameObjectFactory.BuildFromXML("test.xml");

            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.Components.Count, copy.Components.Count);
            Assert.AreEqual(copy, copy.Children[0].Parent);
        }

        [TestMethod]
        public void TestCanSerialiseGoWithNoComps() {
            GameObject original = GameObjectFactory.Build("test", new List<IComponent>());

            XMLSerialisation.ConstructXML(original, "test.xml");
            GameObject copy = GameObjectFactory.BuildFromXML("test.xml");

            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.Components.Count, copy.Components.Count);
        }

        [TestMethod]
        public void TestFileNotFound() {
            GameObject go = GameObjectFactory.BuildFromXML("notfound.xml");
            Assert.IsNotNull(go);
        }

        [TestMethod]
        public void TestReliesOnSystem() {
            MockSystem mockSystem = new MockSystem();
            SystemManager.AddSystems(new List<ISystem>() { mockSystem });
            GameObject original = GameObjectFactory.Build(new List<IComponent>() {new MockReliesOnSystem()});

            XMLSerialisation.ConstructXML(original, "test.xml");
            GameObject copy = GameObjectFactory.BuildFromXML("test.xml");

            Assert.AreEqual(mockSystem, copy.GetComponent<MockReliesOnSystem>().System);

        }
    }
}