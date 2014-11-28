using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds;
using CSharpMinds.Interfaces;
using CSharpMinds.Resources;
using CSharpMinds.Managers;
using System.Drawing;
using System.IO;

namespace Tests
{
    [TestClass]
    public class ResourceTests
    {
        ResourceManager resources;
        Resource r;
        ImageResource i;

        [TestInitialize]
        public void Setup()
        {
            Directory.SetCurrentDirectory("C:\\Users\\jack\\Documents\\awgp14-c-minds\\CSharpMinds\\Images");
            Console.Out.WriteLine("The current directory is {0}", Directory.GetCurrentDirectory());

            resources = new ResourceManager();
            r = new Resource("testDirectory","testName");
            i = new ImageResource("citadel.jpg","testImage");
        }

        [TestMethod]
        public void TestBitmapLoad()
        {
            Bitmap img = (Bitmap)Image.FromFile("citadel.jpg");
            Assert.AreEqual(i.Img.ToString(), img.ToString());
        }
    }
}
