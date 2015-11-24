using System;
using System.Collections.Concurrent;

namespace Serialization
{
    class XmlSerializer<T> : ISerializable<T>
    {
        static ConcurrentDictionary<Type, XmlSerializerAdapter> serializers;

        public XmlSerializer()
        {
            if (serializers == null)
                serializers = new ConcurrentDictionary<Type, XmlSerializerAdapter>();
            var type = typeof(T);
            if (!serializers.ContainsKey(type))
            {
                var serializer = new XmlSerializerAdapter(type);
                serializers[type] = serializer;
            }
        }

        public string Serialize(T obj)
        {
            return serializers[typeof(T)].Serialize(obj);
        }

        public T Deserialize(string s)
        {
            return (T)serializers[typeof(T)].Deserialize(s);
        }
    }
}
