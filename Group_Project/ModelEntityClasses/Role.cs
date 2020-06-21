using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Roles")]
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}