using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Personal
{
    public class Department
    {
        public Department()
        {
            Staff = new HashSet<Employee>();
        }

        public string ID { get; set; }

        public string Title { get; set; }

        public ICollection<Employee> Staff { get; set; }
    }
}
