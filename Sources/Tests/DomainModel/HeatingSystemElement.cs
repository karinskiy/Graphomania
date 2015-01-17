using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public abstract class HeatingSystemElement
    {
        protected HeatingSystemElement(string name, HeatingSystemElement owner)
        {
            this.Name = name;
            this.Owner = owner;
        }

        public string Name { get; set; }

        public HeatingSystemElement Owner { get; set; }

        public string Description { get; set; }

        public Location Location { get; set; }
    }
}
