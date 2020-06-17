using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Interfaces
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
