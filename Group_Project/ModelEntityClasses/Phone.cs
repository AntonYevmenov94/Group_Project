using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Phones")]
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public int PeopleId { get; set; }
        [ForeignKey(nameof(PeopleId))]
        public virtual Person Person { get; set; }
    }
}
