using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("Responses")]
    public class Response : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int VacancyId { get; set; }
        [ForeignKey(nameof(VacancyId))]
        public virtual Vacancy Vacancy { get; set; }
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

    }
}