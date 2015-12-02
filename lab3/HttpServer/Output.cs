using System;

namespace HttpServer
{
    [Serializable]
    public class Output
    {
        public decimal SumResult { get; set; }
        public int MulResult { get; set; }
        public decimal[] SortedInputs { get; set; }
    }
}
