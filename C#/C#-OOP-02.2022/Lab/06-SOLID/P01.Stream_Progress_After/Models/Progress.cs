using P01.Stream_Progress_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress_After.Models
{
    public class Progress
    {
        private readonly IStream stream;

        public Progress(IStream stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}
