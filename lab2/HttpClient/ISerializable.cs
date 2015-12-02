namespace HttpClient
{
    public interface ISerializable
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string s);
    }
}