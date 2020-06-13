using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RolesId { get; set; }
        [ForeignKey(nameof(RolesId))]
        public virtual Roles Role { get; set; }

    }
}