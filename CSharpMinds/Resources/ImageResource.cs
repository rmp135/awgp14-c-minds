using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds;
using System.Drawing;

namespace CSharpMinds.Resources
{
    public class ImageResource : Resource
    {
        private Bitmap img;
        public ImageResource(string filepath, string name) : base(filepath, name)
        {
            img = (Bitmap)Image.FromFile(filepath);
        }

        public Bitmap Img
        {
            get { return img; }
            set { this.img = value; }
        }
    }
}
