using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds;
using System.Drawing;


namespace CSharpMinds
{
    public class ImageResource : Resource
    {

        public ImageResource(string filepath, string name) : base(filepath, name)
        {
            img = (Bitmap)Image.FromFile(filePath);
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

        public Bitmap img
        {
            get { return img; }
            set { this.img = value; }
        }
    }
}
