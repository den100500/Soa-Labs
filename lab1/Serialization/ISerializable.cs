namespace Serialization
{
    public interface ISerializable<T>
    {
        string Serialize(T obj);
        T Deserialize(string s);
    }
}
