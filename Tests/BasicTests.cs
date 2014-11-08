﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMinds;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using Common;
using Tests.Components;

namespace CSharpMinds.Tests {

    [TestClass]
    public class BasicTests {
        GameObject go;
        MockUpdateComponent c;

        [TestInitialize]
        public void Setup() {
            go = new GameObject("go");
            c = new MockUpdateComponent();
        }

        [TestMethod]
        public void TestCanGetComponentByName() {
            go.AddComponent(c);
            IComponent s = go.GetComponentByName("UpdatingComp");
            Assert.AreEqual("UpdatingComp", s.Name);
        }

        [TestMethod]
        public void TestComponentsUpdate() {
            go.AddComponent(c);
            c.Update(new GameTime());
            Assert.AreEqual(1, c.TestInt);
        }

        [TestMethod]
        public void TestCastingComponents() {
            go.AddComponent(c);
            MockUpdateComponent s = go.GetComponentByName("UpdatingComp") as MockUpdateComponent;
            Assert.AreEqual(0, s.TestInt);
        }

        [TestMethod]
        public void TestVectorOperands() {
            Vector v = new Vector(2f, 3f, 4f);
            Vector v2 = new Vector(1f, 2f, 3f);
            Assert.AreEqual(new Vector(3f, 5f, 7f), v + v2);
        }

    }
}
