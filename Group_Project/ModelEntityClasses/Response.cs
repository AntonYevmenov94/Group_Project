using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Responses")]
    public class Response
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int VacancyId { get; set; }
        [ForeignKey(nameof(VacancyId))]
        public virtual Vacancy Vacancy { get; set; }
        public int PeopleId { get; set; }
        [ForeignKey(nameof(PeopleId))]
        public virtual People People { get; set; }

    }
}
