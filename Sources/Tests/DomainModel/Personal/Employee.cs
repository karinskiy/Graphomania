using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Personal
{
    public class Employee
    {
        public Employee()
        {
            Subordinates = new HashSet<Employee>();
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public string Post { get; set; }

        public ICollection<Employee> Subordinates { get; set; }

        public Employee Chief { get; set; }
    }
}
