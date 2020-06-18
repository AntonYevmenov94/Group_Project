using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual User User { get; set; }


        public int? PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]

        public virtual Person Person { get; set; }
    }
}