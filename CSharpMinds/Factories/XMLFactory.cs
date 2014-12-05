using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpMinds.Factories
{
    public static class XMLFactory
    {

        public static T CreateFromXml<T>(string filepath)
        {
            XmlSerializer reader = new XmlSerializer(typeof(T));
            StreamReader file = new StreamReader(filepath);
            T t = (T)reader.Deserialize(file);

            return t;
        }
    }
}
