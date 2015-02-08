﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.CommandTranslator.DatabaseAdapter
{
    public abstract class DbCommand
    {
        public abstract IEnumerable<DataRecord> Execute();
    }
}
