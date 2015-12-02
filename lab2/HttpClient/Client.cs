namespace HttpClient
{
    class Client : ClientBase
    {
        static JsonSerializer serializer = new JsonSerializer();

        public Client(string host, string port) : base(host, port) { }

        public bool Ping()
        {
            try
            {
                Post("Ping", string.Empty);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Input GetInputData()
        {
            return serializer.Deserialize<Input>(Post("GetInputData", string.Empty));
        }

        public void WriteAnswer(Output answer)
        {
            Post("WriteAnswer", serializer.Serialize(answer));
        }
    }
}