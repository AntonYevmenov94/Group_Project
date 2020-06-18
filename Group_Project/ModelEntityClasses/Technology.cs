using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Technologies")]
    public class Technology
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }

        public Technology()
        {
            People = new HashSet<Person>();
            Disciplines = new HashSet<Discipline>();
        }

    }
}