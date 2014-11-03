using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Managers
{
    class ResourceManager
    {
        List<Resource> resources;
        public ResourceManager()
        {
            resources = new List<Resource>();
        }

        public Resource LoadBitmap(string filePath)
        {
            Bitmap b = (Bitmap)Image.FromFile(filePath, true);

            Resource r = new Resource(b);
            resources.Add(r);

            return r;
        }

        //public Resource LoadTextFile(string filePath)
        //{
            
        //}

        public List<Resource> getResources()
        {
            return resources;
        }
    }
}
