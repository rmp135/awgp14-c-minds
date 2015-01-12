using CSharpMinds;
using CSharpMinds.Components;
using CSharpMinds.Factories;
using CSharpMinds.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests.Mocks;

namespace Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void TestXmlFactoryCreate()
        {
            MockPlayer p = XMLFactory.CreateFromXml<MockPlayer>(@"Mocks\MockPLayerSample.xml");
            MockDetails d = new MockDetails();
            d.name = "Jack Hames";
            d.age = "21";

            p.details = d;

            Assert.AreEqual(p.lives, 3);
            Assert.AreEqual(p.details.name, "Jack Hames");
            Assert.AreEqual(p.score, 2039);
        }

        [TestMethod]
        public void TestXmlFactoryReadAndUpdate()
        {
            MockPlayer p = XMLFactory.CreateFromXml<MockPlayer>(@"Mocks\MockPLayerSample.xml");

            p.lives = 101;
            p.details.name = "name change";
            p.score = 765345;

            XMLFactory.ReadAndUpdateFromXml<MockPlayer>(@"Mocks\MockPLayerSample.xml", p);
        }

        [TestMethod]
        public void TestXmlFactoryWriteToXml()
        {
            MockPlayer p = XMLFactory.CreateFromXml<MockPlayer>(@"Mocks\MockPLayerSample.xml");

            p.lives = 1;
            p.details.age = "21";
            p.details.name = "Jack";
            p.score = 0;

            XMLFactory.WriteToXml<MockPlayer>(@"Mocks\NewMockPlayer.xml", p);
        }

        [TestMethod]
        public void TestGOFactoryAddsComponent() {
            GameObject g = GameObjectFactory.Build(new List<IComponent>() { new TransformComponent() });

            Assert.AreEqual("Transform", g.GetComponent<TransformComponent>().Name);
        }

        [TestMethod]
        public void TestGOSetsComponentOwner() {
            TransformComponent tc = new TransformComponent();

            GameObject g = GameObjectFactory.Build(new List<IComponent>() { tc });

            Assert.AreEqual(g, tc.Owner);
        }

        [TestMethod]
        public void TestGOSetsCompThatReliesOnAnotherComps() {
            MockUpdateComponent tc = new MockUpdateComponent();
            MockReliesOnComponent trc = new MockReliesOnComponent();

            GameObject g = GameObjectFactory.Build(new List<IComponent>() { tc, trc });

            Assert.AreEqual(g, tc.Owner);
            Assert.AreEqual(g, trc.Owner);
        }

        [TestMethod]
        public void DisableCompOnMissingRequiredComp() {
            MockReliesOnComponent trc = new MockReliesOnComponent();

            GameObject g = GameObjectFactory.Build(new List<IComponent>() { trc });
            Assert.IsFalse(trc.Enabled);
        }

        [TestMethod]
        public void DisableCompOnMissingRequiredSystem() {
            MockReliesOnSystem ros = new MockReliesOnSystem();
            GameObject g = GameObjectFactory.Build(new List<IComponent>() { ros });
            Assert.IsFalse(ros.Enabled);
        }
    }
}