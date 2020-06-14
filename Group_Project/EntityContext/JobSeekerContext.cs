using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class JobSekeerContext : DbContext
    {
        public JobSekeerContext() : base("job")
        {
            //Database.SetInitializer(new MyInitializer());
            //Database.SetInitializer(new DropCreateDatabaseAlways<JobSekeerContext>());

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }






        public class MyInitializer : DropCreateDatabaseAlways<JobSekeerContext>
        {
            protected override void Seed(JobSekeerContext context)
            {
                Role roles1 = new Role() { Id = 1, Title = "Director" };
                Role roles2 = new Role() { Id = 2, Title = "HR" };
                Role roles3 = new Role() { Id = 3, Title = "MUP" };
                context.Roles.AddRange(new[] { roles1, roles2, roles3 });
                context.SaveChanges();
            }
        }
    }
}