using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Logs")]
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public DateTime Time { get; set; }


        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User Users { get; set; }


        public int PeopleId { get; set; }
        [ForeignKey(nameof(PeopleId))]

        public virtual Person Person { get; set; }
    }
}