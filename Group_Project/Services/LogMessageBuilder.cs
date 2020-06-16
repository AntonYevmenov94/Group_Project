using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Services
{
    class LogMessageBuilder : ILogMessageBuilder
    {
        // authService передается единственным экземпляром по всему приложению, для отслеживание текущего пользователя.
        // Поэтому не нужно передавать его отдельным параметром метода.
        private IAuthService authService;

        public LogMessageBuilder(IAuthService authService)
        {
            this.authService = authService;
        }

        /// <summary>
        /// Возращает отформатированное строковое представление текущего времени.
        /// Используется для того, чтобы было легче менять формат времени во всех создаваемых
        /// сообщениях лога.
        /// </summary>
        /// <returns>Строку текущей даты времени.</returns>
        private string GetFormattedTime()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        }

        public string GetLogMessage(LogAction action, string objectOfAction)
        {
            //throw new NotImplementedException();

            // как пример
            switch (action)
            {
                case LogAction.UserCreated:
                    return $"{authService.LoggedUser.Login} создал пользователя {objectOfAction} [{GetFormattedTime()}]";
                default:
                    return "no message";
            }
        }

        public string GetLogMessage(LogAction action, string objectOfAction, string changedProperty, string oldValue, string newValue)
        {
            //throw new NotImplementedException();

            // как пример
            switch (action)
            {
                case LogAction.UserChanged:
                    return $"{authService.LoggedUser.Login} изменил {changedProperty} пользователя {objectOfAction} с '{oldValue}' на '{newValue}' [{GetFormattedTime()}]";
                default:
                    return "no message";
            }
        }
    }
}
