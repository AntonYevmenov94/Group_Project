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
        void LogAction(string logMessage, Person subject = null);
    }
}
