using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.CommandTranslator
{
    using Graphomania.CommandTranslator.DatabaseAdapter;
    using Graphomania.ObjectGraphInspector.Model;
    using Graphomania.ObjectGraphInspector.Read.Queries;

    public interface IQueryToCommandTranslator
    {
        IEnumerable<DbCommand> ToCommands(Query query);
    }
}
