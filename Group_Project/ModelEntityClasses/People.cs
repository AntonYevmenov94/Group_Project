using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("People")]
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
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
        public virtual ICollection<Technology> Technologies { get; set; }
        public virtual ICollection<Log> Logs { get; set; }

        public People()
        {
            SocialMediaLinks = new HashSet<SocialMediaLink>();
            Technologies = new HashSet<Technology>();
            Logs = new HashSet<Log>();
        }


    }
}
