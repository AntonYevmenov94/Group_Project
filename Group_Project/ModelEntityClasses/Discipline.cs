using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Disciplines")]
    public class Discipline : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }

        public Discipline()
        {
            Vacancies = new HashSet<Vacancy>();
            Technologies = new HashSet<Technology>();
        }

    }
}