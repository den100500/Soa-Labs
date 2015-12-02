using System.Net;

namespace HttpServer
{
    public interface IServer
    {
        string GetRequestBody();
        void WriteResponse(string data);
    }
}
