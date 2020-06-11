using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Technologies")]
    public class Technology
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }

        public Technology()
        {
            People = new HashSet<People>();
            Disciplines = new HashSet<Discipline>();
        }

    }
}
