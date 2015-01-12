using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpMinds.Resources
{
    class TextResource : Resource
    {
        private int lineCount;
        private string stringBuffer;
        private List<string> textFileLines;

        public TextResource(string filePath, string name) : base(filePath, name)
        {
            string[] lines = File.ReadAllLines(filePath);

            textFileLines = new List<string>();
            lineCount = lines.Length;

            for (int i = 0; i < lineCount; i++)
            {
                textFileLines.Add(lines[i]);
            }
        }

        public int LineCount
        {
            get { return lineCount; }
        }

        public List<string> TextFile
        {
            get { return textFileLines; }
        }

        public string getLineAt(int linePos)
        {
            stringBuffer = textFileLines.ElementAt(linePos);
            return stringBuffer;
        }
    }
}
