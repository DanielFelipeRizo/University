﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    internal class Enterprise
    {
        public int id { get; set; }
        public string? name { get; set; }
        public Employee[]? employees { get; set; } = new Employee[0];
    }
}
