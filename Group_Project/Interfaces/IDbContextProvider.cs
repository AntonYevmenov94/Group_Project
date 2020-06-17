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
        JobSeekerDbContext GetDbContext();

        /// <summary>
        /// Инкапсулирует попытку сохранить сделанные изменения в БД. Исключения брошенные в процессе выполнения игнорируются!
        /// </summary>
        /// <returns>Успешность операции. true - операция завершилась успешно, false - во время операции возникли проблемы. </returns>
        bool TrySaveChanges();
    }
}
