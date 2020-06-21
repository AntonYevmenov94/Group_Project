using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Users")]
    public class User : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsLoggedIn { get; set; }
        public int RolesId { get; set; }
        [ForeignKey(nameof(RolesId))]
        public virtual Role Role { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}