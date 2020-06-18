using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
