﻿using System;

namespace HttpServer
{
    [Serializable]
    public class Input
    {
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }
    }
}
