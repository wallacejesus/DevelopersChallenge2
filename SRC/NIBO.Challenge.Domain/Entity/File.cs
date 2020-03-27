using System;
using System.Collections.Generic;
using System.Text;

namespace NIBO.Challenge.Domain.Entity
{
    public class File:Base
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
