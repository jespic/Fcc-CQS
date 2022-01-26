﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Core.Data.Connection
{
    public sealed class ConnectionString
    {
        public string Value { get; set; }
        public ConnectionString(string value)
        {
            Value = value;
        }
    }
}
