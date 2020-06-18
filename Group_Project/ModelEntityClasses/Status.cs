using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Statuses")]
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}