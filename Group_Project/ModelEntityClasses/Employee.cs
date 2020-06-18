using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; }


    }
}
