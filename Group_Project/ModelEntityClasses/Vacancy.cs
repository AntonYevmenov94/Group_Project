using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Vacancies")]
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Archived { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public Vacancy()
        {
            Disciplines = new HashSet<Discipline>();
            Responses = new HashSet<Response>();
        }
    }
}
