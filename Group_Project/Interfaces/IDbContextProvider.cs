using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Group_Project
{
    /// <summary>
    /// Сервис для обеспечения доступа к контексту БД.
    /// </summary>
    public interface IDbContextProvider
    {
        string ConnectionString { get; set; }
        JobSeekerDbContext GetDbContext();
        void RefreshDbContext();
    }
}
