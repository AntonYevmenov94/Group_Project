using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Disciplines")]
    public class Discipline
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }

        public Discipline()
        {
            Vacancies = new HashSet<Vacancy>();
            Technologies = new HashSet<Technology>();
        }

    }
}