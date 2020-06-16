using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    // логгер отделяется от сервиса для создания сообщений лога, чтобы
    // было легче менять логгер

    /// <summary>
    /// Сервис для логирования действий.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Создать новую запись в таблице БД Log.
        /// </summary>
        /// <param name="logMessage">Текстовое сообщение.</param>
        /// <param name="subject">Субъект, над которым было произведено логируемое дейтсвие.</param>
        void LogAction(string logMessage, Person subject = null);
    }
}
