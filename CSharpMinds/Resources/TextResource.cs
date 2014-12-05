using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Resources
{
    class TextResource : Resource
    {
        private int lineCount;
        private string stringBuffer;
        private List<string> textFileLines;

        public TextResource(string filePath, string name) : base(filePath, name)
        {

        }

        public int LineCount
        {
            get { return lineCount; }
        }
    }
}
