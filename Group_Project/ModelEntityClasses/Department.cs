using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Departments")]
    public class Department : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Title { get; set; }

    }
}
