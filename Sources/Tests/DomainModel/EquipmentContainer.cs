using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class EquipmentContainer : Connectable
    {
        public EquipmentContainer(string name, HeatingNetwork owner) : base(name, owner)
        {
        }

        public EquipmentContainer(string name, EquipmentContainer owner) : base(name, owner)
        {
        }
    }
}
