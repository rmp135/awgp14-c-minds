using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds
{
    public class Resource : IResource
    {

        public Resource(string filepath, string name)
        {
            this.name = name;
            this.filePath = filepath;
        }

        public string name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string filePath
        {
            get { return filePath; }
            set { this.filePath = value; }
        }
    }
}
