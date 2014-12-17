using CSharpMinds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpMinds.Components
{
    /// Serialising interfaces via: http://www.codeproject.com/Articles/738100/XmlSerializer-Serializing-list-of-interfaces
    
    public class IComponentList : List<IComponent>, IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader) {
            if (!reader.IsEmptyElement) {
                reader.ReadStartElement("Components");
                while (reader.IsStartElement("IComponent")) {
                    Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                    XmlSerializer serial = new XmlSerializer(type);

                    reader.ReadStartElement("IComponent");
                    this.Add((IComponent)serial.Deserialize(reader));
                    reader.ReadEndElement();
                }
                    reader.ReadEndElement();
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer) {
            foreach (IComponent component in this) {
                writer.WriteStartElement("IComponent");
                writer.WriteAttributeString("AssemblyQualifiedName", component.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(component.GetType());
                xmlSerializer.Serialize(writer, component);
                writer.WriteEndElement();
            }
        }
    }
}
