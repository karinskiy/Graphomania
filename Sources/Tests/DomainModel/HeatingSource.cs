using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class HeatingSource : EquipmentContainer
    {
        public HeatingSource(string name, HeatingNetwork owner) : base(name, owner)
        {
        }
    }
}
