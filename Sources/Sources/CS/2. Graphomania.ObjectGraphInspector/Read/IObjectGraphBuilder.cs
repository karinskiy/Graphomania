using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.ObjectGraphInspector.Read
{
    using Graphomania.ObjectGraphInspector.Model;

    public interface IObjectGraphBuilder
    {
        object Build(IEnumerable<ObjectGraphElement> objectGraphElements);
    }
}
