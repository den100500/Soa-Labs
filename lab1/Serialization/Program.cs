using System;
using System.Linq;

namespace Serialization
{
    class Program
    {
        static Output Convert(Input data)
        {
            var answer = new Output();
            answer.SumResult = data.Sums.Sum() * data.K;
            answer.MulResult = data.Muls.Aggregate((a, b) => a * b);
            answer.SortedInputs =   Array.ConvertAll(data.Muls, x => (decimal)x)
                                    .Concat(data.Sums)
                                    .OrderBy(x => x)
                                    .ToArray();
            return answer;
        }

        static void Main(string[] args)
        {
            string serializationType = Console.ReadLine();
            string serializedObject = Console.ReadLine();
            Input input;
            Output output;
            ISerializable<Input> inputSerializer;
            ISerializable<Output> outputSerializer;
            if (serializationType == "Xml")
            {
                inputSerializer = new XmlSerializer<Input>();
                outputSerializer = new XmlSerializer<Output>();
            }
            else
            {
                inputSerializer = new JsonSerializer<Input>();
                outputSerializer = new JsonSerializer<Output>();
            }

            input = inputSerializer.Deserialize(serializedObject);
            output = Convert(input);
            if (serializationType == "Json")
            {
                for (int i = 0; i < output.SortedInputs.Length; i++)
                    output.SortedInputs[i] += 0.1m;
                for (int i = 0; i < output.SortedInputs.Length; i++)
                    output.SortedInputs[i] -= 0.1m;
            }
            Console.Write(outputSerializer.Serialize(output));
        }
    }
}
