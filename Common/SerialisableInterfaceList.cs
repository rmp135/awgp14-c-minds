using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    /// Serialising interfaces via: http://www.codeproject.com/Articles/738100/XmlSerializer-Serializing-list-of-interfaces
    
    public class SerialisableInterfaceList<T> : List<T>, IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader) {
            if (!reader.IsEmptyElement) {
                reader.ReadStartElement();
                while (reader.IsStartElement(typeof(T).ToString())) {
                    Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                    XmlSerializer serial = new XmlSerializer(type);

                    reader.ReadStartElement(typeof(T).ToString());
                    this.Add((T)serial.Deserialize(reader));
                    reader.ReadEndElement();
                }
                    reader.ReadEndElement();
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer) {
            foreach (T item in this) {
                writer.WriteStartElement(typeof(T).ToString());
                writer.WriteAttributeString("AssemblyQualifiedName", item.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(item.GetType());
                xmlSerializer.Serialize(writer, item);
                writer.WriteEndElement();
            }
        }
    }
}
