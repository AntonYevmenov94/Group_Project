using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("SocialMediaLinks")]
    public class SocialMediaLink
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }
    }
}