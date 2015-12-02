using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HttpClient
{
    class ClientBase : IClient
    {
        string prefix;

        protected ClientBase(string host, string port)
        {
            prefix = string.Format("{0}:{1}", host, port);
        }

        public string Post(string method, string data)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}/", prefix, method));
            request.Method = "POST";
            request.Timeout = 2000;
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            if (data != null)
                request.GetRequestStream().Write(bytes, 0, bytes.Length);
            List<byte> responseBytes = new List<byte>();
            using (var stream = request.GetResponse().GetResponseStream())
            {
                while (true)
                {
                    var b = stream.ReadByte();
                    if (b == -1)
                        break;
                    responseBytes.Add((byte)b);
                }
            }
            return Encoding.UTF8.GetString(responseBytes.ToArray());
        }
    }
}