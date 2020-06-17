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


            var vacancies = new List<Vacancy>
            {
                new Vacancy(){Title="Vacancy1", Archived=true, Description="Description1", StartDate=DateTime.Now, EndDate=DateTime.Now },
                new Vacancy(){Title="Vacancy2", Archived=true, Description="Description2", StartDate=DateTime.Now, EndDate=DateTime.Now },
                new Vacancy(){Title="Vacancy3", Archived=false, Description="Description3", StartDate=DateTime.Now, EndDate=DateTime.Now },
                new Vacancy(){Title="Vacancy4", Archived=false, Description="Description4", StartDate=DateTime.Now, EndDate=DateTime.Now }
            };
            context.Vacancies.AddRange(vacancies);
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department(){Title="Department1"},
                new Department(){Title="Department2"},
                new Department(){Title="Department3"},
                new Department(){Title="Department4"},
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            var sex = new List<Sex>
            {
                new Sex(){Title="Мужчина"},
                new Sex(){Title="Женщина"},
                new Sex(){Title="Не определен"}
            };
            context.Sex.AddRange(sex);
            context.SaveChanges();

            var statuses = new List<Status>
            {
                new Status(){Name="Кандидат"},
                new Status(){Name="Собеседование"},
                new Status(){Name="Техсобеседование"},
                new Status(){Name="Стажировка"},
                new Status(){Name="Принят на работу"}
            };
            context.Statuses.AddRange(statuses);
            context.SaveChanges();

            var disciplines = new List<Discipline>
            {
                new Discipline(){Title="Discipline1"},
                new Discipline(){Title="Discipline2"},
                new Discipline(){Title="Discipline3"},
            };
            context.Disciplines.AddRange(disciplines);
            context.SaveChanges();

            var technologies = new List<Technology>
            {
                new Technology(){Title="Technology1"},
                new Technology(){Title="Technology2"},
                new Technology(){Title="Technology3"},
                new Technology(){Title="Technology4"}
            };
            context.Technologies.AddRange(technologies);
            context.SaveChanges();

            var persons = new List<Person>
            {
                new Person(){Name="Name1", Surname="Surname1", Patronymic="Patronymic1", Age=18, SexId=1, StatusId=1, Experience="Experience1", Education="Education1", Stars=1},
                new Person(){Name="Name2", Surname="Surname2", Patronymic="Patronymic2", Age=22, SexId=1, StatusId=2, 
                    Experience="Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину "+
                "Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину",
                    Education="Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину "+
                "Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину", Stars=2},
                new Person(){Name="Name3", Surname="Surname3", Patronymic="Patronymic3", Age=16, SexId=2, StatusId=3, Experience="Experience3", Education="Education3", Stars=3},
                new Person(){Name="Name4", Surname="Surname4", Patronymic="Patronymic4", Age=31, SexId=2, StatusId=4, Experience="Experience4", Education="Education4", Stars=4},
                new Person(){Name="Name5", Surname="Surname5", Patronymic="Patronymic5", Age=41, SexId=3, StatusId=5, Experience="Experience5", Education="Education5", Stars=5},
                new Person(){Name="Name6", Surname="Surname6", Patronymic="Patronymic6", Age=55, SexId=3, StatusId=5, Experience="Experience6", Education="Education6", Stars=5},
                new Person(){Name="Name7", Surname="Surname7", Patronymic="Patronymic7", Age=19, SexId=3, StatusId=5, Experience="Experience7", Education="Education7", Stars=5},
                new Person(){Name="Name8", Surname="Surname8", Patronymic="Patronymic8", Age=15, SexId=3, StatusId=5, Experience="Experience8", Education="Education8", Stars=5},
                new Person(){Name="Name9", Surname="Surname9", Patronymic="Patronymic9", Age=74, SexId=3, StatusId=5, Experience="Experience9", Education="Education9", Stars=5},
                new Person(){Name="Name10", Surname="Surname10", Patronymic="Patronymic10", Age=53, SexId=3, StatusId=5, Experience="Experience10", Education="Education10", Stars=5},
                new Person(){Name="Name11", Surname="Surname11", Patronymic="Patronymic11", Age=44, SexId=3, StatusId=5, Experience="Experience11", Education="Education11", Stars=5},
                new Person(){Name="Name12", Surname="Surname12", Patronymic="Patronymic12", Age=33, SexId=3, StatusId=5, Experience="Experience12", Education="Education12", Stars=5},
                new Person(){Name="Name13", Surname="Surname13", Patronymic="Patronymic13", Age=32, SexId=3, StatusId=5, Experience="Experience13", Education="Education13", Stars=5},
                new Person(){Name="Name14", Surname="Surname14", Patronymic="Patronymic14", Age=36, SexId=3, StatusId=5, Experience="Experience14", Education="Education14", Stars=5},
                new Person(){Name="Name15", Surname="Surname15", Patronymic="Patronymic15", Age=27, SexId=3, StatusId=5, Experience="Experience15", Education="Education15", Stars=5}
            };
            context.Persons.AddRange(persons);
            context.SaveChanges();

            var users = new List<User>
            {
                new User(){Login="login1", Password="password1", Email="Email1@gmail.com", RolesId=4, IsLoggedIn=false},
                new User(){Login="login2", Password="password2", Email="Email1@gmai2.com", RolesId=3, IsLoggedIn=false},
                new User(){Login="login3", Password="password3", Email="Email1@gmai3.com", RolesId=2, IsLoggedIn=true},
                new User(){Login="1", Password="1", Email="Email4@gmail.com", RolesId=1, IsLoggedIn=true}
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment(){Text="Comment1", PersonId=1, UserId=1},
                new Comment(){Text="Comment2", PersonId=2, UserId=2},
                new Comment(){Text="Comment3", PersonId=3, UserId=3},
                new Comment(){Text="Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину "+
                "Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину", PersonId=4, UserId=1}
            };
            context.Comments.AddRange(comments);
            context.SaveChanges();

            var emails = new List<Email>
            {
                new Email(){Address="UserEmail1@gmail.com", PersonId=1},
                new Email(){Address="UserEmail1@gmai2.com", PersonId=1},
                new Email(){Address="UserEmail1@gmai3.com", PersonId=1},
                new Email(){Address="UserEmail1@gmai4.com", PersonId=1}
            };
            context.Emails.AddRange(emails);
            context.SaveChanges();

            var positions = new List<Position>
            {
                new Position(){Title="Position1", DepartmentId=1},
                new Position(){Title="Position2", DepartmentId=2},
                new Position(){Title="Position3", DepartmentId=3}
            };
            context.Positions.AddRange(positions);
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee(){PersonId=1,PositionId=1,Salary=20000,EmploymentDate=DateTime.Now},
                new Employee(){PersonId=2,PositionId=2,Salary=30000,EmploymentDate=DateTime.Now},
                new Employee(){PersonId=3,PositionId=3,Salary=40000,EmploymentDate=DateTime.Now},
                new Employee(){PersonId=4,PositionId=3,Salary=50000,EmploymentDate=DateTime.Now},
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            var log = new List<Log>
            {
                new Log(){Message="Message1", PersonId=1, UserId=1, Time=DateTime.Now},
                new Log(){Message="Message2", PersonId=2, UserId=2, Time=DateTime.Now},
                new Log(){Message="Message3", PersonId=3, UserId=3, Time=DateTime.Now},
                new Log(){Message="Message4", PersonId=4, UserId=4, Time=DateTime.Now},
                new Log(){Message="Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину "+
                "Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину Тест на длину", PersonId=1, UserId=1, Time=DateTime.Now}
            };
            context.Log.AddRange(log);
            context.SaveChanges();

            var phones = new List<Phone>
            {
                new Phone(){Number="0960000001", PersonId=1},
                new Phone(){Number="0960000002", PersonId=2},
                new Phone(){Number="0960000003", PersonId=3},
                new Phone(){Number="0960000004", PersonId=4},
                new Phone(){Number="0960000005", PersonId=5},
                new Phone(){Number="0960000006", PersonId=6},
                new Phone(){Number="0960000007", PersonId=7},
                new Phone(){Number="0960000008", PersonId=8},
                new Phone(){Number="0960000009", PersonId=9},
                new Phone(){Number="09600000010", PersonId=10},
                new Phone(){Number="09600000011", PersonId=11},
                new Phone(){Number="09600000012", PersonId=12},
                new Phone(){Number="09600000013", PersonId=13},
                new Phone(){Number="09600000014", PersonId=14},
                new Phone(){Number="09600000015", PersonId=15}
            };
            context.Phones.AddRange(phones);
            context.SaveChanges();

            var responses = new List<Response>
            {
                new Response(){PersonId=1, VacancyId=1, Time=DateTime.Now},
                new Response(){PersonId=2, VacancyId=2, Time=DateTime.Now},
                new Response(){PersonId=3, VacancyId=3, Time=DateTime.Now},
                new Response(){PersonId=4, VacancyId=4, Time=DateTime.Now},
                new Response(){PersonId=5, VacancyId=1, Time=DateTime.Now}
            };
            context.Responses.AddRange(responses);
            context.SaveChanges();

            var socialMediaLinks = new List<SocialMediaLink>
            {
                new SocialMediaLink(){PersonId=1, Link="https://www.linkedin.com/in/markos-basilio-0ba606194/"},
                new SocialMediaLink(){PersonId=2, Link="https://www.linkedin.com/in/ruban-serhii/"},
                new SocialMediaLink(){PersonId=3, Link="https://www.linkedin.com/in/davyd-bukhbinder-a21802197/"},
                new SocialMediaLink(){PersonId=4, Link="https://www.linkedin.com/in/vadym-kharlamenko-07671b8a/"},
                new SocialMediaLink(){PersonId=5, Link="https://www.linkedin.com/in/inga-kovnitska-876803197/"},
                new SocialMediaLink(){PersonId=1, Link="https://www.facebook.com/profile.php?id=100014282527366"},
                new SocialMediaLink(){PersonId=1, Link="https://www.instagram.com/markus.x6m/?hl=ru"}
            };
            context.SocialMediaLinks.AddRange(socialMediaLinks);
            context.SaveChanges();
        }
    }
}