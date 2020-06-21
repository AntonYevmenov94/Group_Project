using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Roles")]
    public class Role : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}