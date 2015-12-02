using System;
using System.Linq;

namespace HttpClient
{
    class Program
    {
        static Output Convert(Input data)
        {
            var answer = new Output();
            answer.SumResult = data.Sums.Sum() * data.K;
            answer.MulResult = data.Muls.Aggregate((a, b) => a * b);
            answer.SortedInputs = Array.ConvertAll(data.Muls, x => (decimal)x)
                                    .Concat(data.Sums)
                                    .OrderBy(x => x)
                                    .ToArray();
            return answer;
        }

        static void Main(string[] args)
        {
            string localhost = "http://127.0.0.1";
            string port = Console.ReadLine();
            Client client = new Client(localhost, port);
            while (!client.Ping()) ;
            var input = client.GetInputData();
            var output = Convert(input);
            client.WriteAnswer(output);
        }
    }
}