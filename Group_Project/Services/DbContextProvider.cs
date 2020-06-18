using Group_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Group_Project.Services
{
    public class DbContextProvider : IDbContextProvider
    {
        private JobSeekerDbContext dbContext;
        private readonly string connectionString;

        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        JobSeekerDbContext IDbContextProvider.GetDbContext()
        {
            throw new NotImplementedException();
        }

        public void RefreshDbContext()
        {
            throw new NotImplementedException();
        }
    }
}
