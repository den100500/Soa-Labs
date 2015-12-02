using System;
using System.Web.Script.Serialization;

namespace HttpClient
{
    class JsonSerializer : ISerializable
    {
        static JavaScriptSerializer serializer;

        static JsonSerializer()
        {
            serializer = new JavaScriptSerializer();
        }

        public string Serialize<T>(T obj)
        {
            return serializer.Serialize(obj);
        }

        public T Deserialize<T>(string s)
        {
            return serializer.Deserialize<T>(s);
        }
    }
}