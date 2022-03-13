using P01.Stream_Progress_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress_After.Models
{
    public class File : IStream
    {
        public string Name { get; set; }
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
