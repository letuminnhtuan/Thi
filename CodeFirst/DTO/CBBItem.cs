﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DTO
{
    public class CBBItem
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}
