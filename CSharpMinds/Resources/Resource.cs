using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Resources
{
    public class Resource : IResource
    {
        private string name;
        private string filePath;
        public Resource(string filepath, string name)
        {
            this.name = name;
            this.filePath = filepath;
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { this.filePath = value; }
        }
    }
}
