using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project
{
    [Table("People")]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public byte[] Photo { get; set; }
        public int Stars { get; set; }

        public int SexId { get; set; }
        [ForeignKey(nameof(SexId))]
        public virtual Sex Sex { get; set; }

        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; }

        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
        public virtual ICollection<Log> Logs { get; set; }

        // Свойство для облегчения доступа к возрасту человека
        [NotMapped]
        public int Age
        {
            get
            {
                double daysInYearAvrg = 365.2425;
                var daysDifference = (DateTime.Now - DateOfBirth).TotalDays / daysInYearAvrg;
                return (int)Math.Floor(daysDifference);
            }
        }

        public Person()
        {
            SocialMediaLinks = new HashSet<SocialMediaLink>();
            Emails = new HashSet<Email>();
            Technologies = new HashSet<Technology>();
            Logs = new HashSet<Log>();
        }


    }
}