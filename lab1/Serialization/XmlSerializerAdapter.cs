using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization
{
    class XmlSerializerAdapter : XmlSerializer
    {
        static XmlWriterSettings settings;
        static XmlSerializerNamespaces ns;

        static XmlSerializerAdapter()
        {
            settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            ns = new XmlSerializerNamespaces();
            ns.Add("", "");
        }

        public XmlSerializerAdapter(Type t) : base(t) { }

        public string Serialize(Object o)
        {
            var ms = new MemoryStream();
            var writer = XmlWriter.Create(ms, settings);
            Serialize(writer, o, ns);
            return Encoding.Default.GetString(ms.ToArray().Skip(3).ToArray());
        }

        public object Deserialize(string s)
        {
            var ms = new MemoryStream();
            ms.Write(Array.ConvertAll(s.ToArray(), x => (byte)x), 0, s.Length);
            ms.Position = 0;
            var reader = XmlReader.Create(ms);
            return Deserialize(reader);
        }
    }
}