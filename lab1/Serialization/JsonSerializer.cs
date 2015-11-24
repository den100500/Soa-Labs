using System.Web.Script.Serialization;

namespace Serialization
{
    class JsonSerializer<T> : ISerializable<T>
    {
        static JavaScriptSerializer serializer;

        static JsonSerializer()
        {
            serializer = new JavaScriptSerializer();
        }

        public string Serialize(T obj)
        {
            return serializer.Serialize(obj);
        }

        public T Deserialize(string s)
        {
            return serializer.Deserialize<T>(s);
        }
    }
}
