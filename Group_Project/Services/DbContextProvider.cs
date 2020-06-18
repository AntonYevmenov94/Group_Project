using System;

namespace Group_Project.Services
{
    public class DbContextProvider : IDbContextProvider
    {
        private JobSeekerDbContext dbContext;
        private readonly string connectionString;


        public DbContextProvider(string connectionString)
        {
            this.connectionString = connectionString;
            dbContext = new JobSeekerDbContext(connectionString);
        }


        public JobSeekerDbContext GetDbContext()
        {
            return dbContext;
        }

        public bool TrySaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
