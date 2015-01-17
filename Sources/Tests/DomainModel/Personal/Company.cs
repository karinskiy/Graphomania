using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Personal
{
    public class Company
    {
        public Company()
        {
            Departments = new HashSet<Department>();
        }

        public string ID { get; set; }

        public string Title { get; set; }

        public ICollection<Department> Departments { get; set; } 
    }
}
