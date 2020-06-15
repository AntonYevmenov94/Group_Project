using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// Сервис для создания сообщений лога действий.
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
