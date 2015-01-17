using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class ConnectionPoint : HeatingSystemElement
    {
        public ConnectionPoint(string name, Connectable owner) : base(name, owner)
        {
        }
    }
}
