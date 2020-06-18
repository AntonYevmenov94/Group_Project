using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Phones")]
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }
    }
}