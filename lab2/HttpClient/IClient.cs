namespace HttpClient
{
    public interface IClient
    {
        string Post(string method, string data);
    }
}