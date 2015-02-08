using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.ObjectGraphInspector.Read.Queries
{
    public abstract class Query
    {
        
    }

    public abstract class Query<T> : Query
    {
        public abstract IEnumerable<T> Evaluate();
    }
}
