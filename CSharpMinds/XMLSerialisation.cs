using System;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpMinds
{
    public static class XMLSerialisation
    {
        public static void ConstructXML(object tosave, string filename) {
            var serialiser = new XmlSerializer(tosave.GetType());
            var xmlTextWriter = XmlTextWriter.Create(filename,
                new XmlWriterSettings { NewLineChars = "\r\n", Indent = true });
            try {
                serialiser.Serialize(xmlTextWriter, tosave);
            }
            catch (Exception e) {
                Console.WriteLine(e.InnerException.Message);
            }
            xmlTextWriter.Close();
        }

        public static object ConstructFromXml<T>(string filename) {
            var serialiser = new XmlSerializer(typeof(T));
            var xmlReader = XmlReader.Create(filename);
            T go = (T)serialiser.Deserialize(xmlReader);
            xmlReader.Close();
            return go;
        }

    }
}
