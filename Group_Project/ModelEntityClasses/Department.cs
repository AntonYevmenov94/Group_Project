using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
}
