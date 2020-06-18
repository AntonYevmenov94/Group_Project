using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Emails")]
    public class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

    }
}