using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Services
{
    class DbContextProvider : IDbContextProvider
    {
        private JobSeekerDbContext DbContext;
        public string ConnectionString { get; set; }

        public JobSeekerDbContext GetDbContext()
        {
            if (DbContext != null)
            {
                return DbContext;
            }
            else
            {
                RefreshDbContext();
                return DbContext;
            }
        }

        public void RefreshDbContext()
        {
            DbContext?.Dispose();
            DbContext = new JobSeekerDbContext(ConnectionString);
        }

        
    }
}
