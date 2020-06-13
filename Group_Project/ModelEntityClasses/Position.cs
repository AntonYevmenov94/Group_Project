using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Positions")]
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

    }
}