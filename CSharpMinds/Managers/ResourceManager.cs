using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CSharpMinds.Interfaces;
using CSharpMinds.Resources;

namespace CSharpMinds.Managers
{
    public class ResourceManager
    {
        List<Resource> resources;
        public ResourceManager()
        {
            resources = new List<Resource>();
        }

        public Resource LoadBitmap(string filePath, string name)
        {

            Resource r = new ImageResource(filePath, name);
            resources.Add(r);

            return r;
        }

        public void AddResource(Resource resource)
        {
            resources.Add(resource);
        }

        public Resource findByName(string name)
        {
            foreach (Resource r in resources) {
                if (r.Name.Equals(name)) {
                    return r;
                }
            }//TODO: throw exception here
            return null;
        }

        public List<Resource> getResources()
        {
            return resources;
        }
    }
}
