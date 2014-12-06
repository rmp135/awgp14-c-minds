using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

            file.Close();

            return t;
        }

        public static void ReadAndUpdateFromXml<T>(string filepath, T obj)
        {
            XmlWriter writer = XmlWriter.Create(filepath);
            XmlSerializer reader = new XmlSerializer(typeof(T));

            reader.Serialize(writer, obj);
        }

        public static void WriteToXml<T>(string filepath, T obj)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(filepath, settings);

            Type t = typeof(T);

            writer.WriteStartElement(obj.GetType().Name);

            foreach (FieldInfo f in t.GetFields())
            {
                writer.WriteStartElement(f.Name);
                writer.WriteString(f.GetValue(obj).ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
        }
    }
}
