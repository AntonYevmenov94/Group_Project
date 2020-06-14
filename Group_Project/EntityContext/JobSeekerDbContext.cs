using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class JobSeekerDbContext : DbContext
    {
        public JobSeekerDbContext() : base("job")
        {
            // ДОЛЖЕН СРАБАТЫВАТЬ ТОЛЬКО ОДИН ИНИЦИАЛИЗАТОР

            // Использовать этот инициализатор, если нет необходимости пересоздавать БД
            // TODO в релизе оставить только этот инициализатор!
            Database.SetInitializer(new SeedInitilizer());

            // Использовать этот иницилизатор, если нужно пересоздать БД. ДАННЫЕ БУДУТ УДАЛЕНЫ
            //Database.SetInitializer(new SeedInitilizerAlwaysRecreateDb());
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





        /// <summary>
        /// Инициализатор БД, заполняющий таблицы с известными неизменными данными.
        /// Релизный вариант, создающий БД только в случае ее отсутствия.
        /// </summary>
        public class SeedInitilizer : CreateDatabaseIfNotExists<JobSeekerDbContext>
        {
            protected override void Seed(JobSeekerDbContext context)
            {
                SeedDbTables(context);
            }
        }

        /// <summary>
        /// Инициализатор БД, заполняющий таблицы с известными неизменными данными.
        /// Пересоздает БД при каждом запуске программы!
        /// </summary>
        public class SeedInitilizerAlwaysRecreateDb: DropCreateDatabaseAlways<JobSeekerDbContext>
        {
            protected override void Seed(JobSeekerDbContext context)
            {
                SeedDbTables(context);
            }
        }


        /// <summary>
        /// Заполняет таблицы в переданном контексте БД.
        /// </summary>
        /// <param name="context"></param>
        private static void SeedDbTables(JobSeekerDbContext context)
        {
            // добавить роли пользователей в программе
            var roles = new List<Role>() {
                    new Role() { Title = "Admin" },     // нужен пользователь с неграниченными правами
                    new Role() { Title = "Director" },
                    new Role() { Title = "HR" },
                    new Role() { Title = "MUP" }        // МУП - менеджер учебного процесса
                };
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}