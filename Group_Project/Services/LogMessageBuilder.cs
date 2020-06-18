using System;

namespace Group_Project.Services
{
    internal class LogMessageBuilder : ILogMessageBuilder
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
            // как пример
            switch (action)
            {
                //добавление пользователя
                case LogAction.UserCreated:
                    return $"{authService.LoggedUser.Login} создал пользователя {objectOfAction} [{GetFormattedTime()}]";
                //удаление пользователя
                case LogAction.UserDeleted:
                    return $"{authService.LoggedUser.Login} удалил пользователя {objectOfAction} [{GetFormattedTime()}]";
                //подтвеждение регистрации пользоватля
                case LogAction.UserRegistration:
                    return $"{authService.LoggedUser.Login} подтвердил регистрацию пользователя {objectOfAction} [{GetFormattedTime()}]";
                default:
                    return "no message";
            }
        }

        public string GetLogMessage(LogAction action, string objectOfAction, string changedProperty, string oldValue, string newValue)
        {
            // как пример
            //изменение роли, изменение информации о пользователе
            switch (action)
            {
                case LogAction.UserChanged:
                    return $"{authService.LoggedUser.Login} изменил {changedProperty} пользователя {objectOfAction} с '{oldValue}' на '{newValue}' [{GetFormattedTime()}]";
                //изменение статуса пользователя
                case LogAction.UserChangedStatus:
                {
                    if (oldValue != newValue)
                    {
                        return $"{objectOfAction} прошел техсобеседование [{GetFormattedTime()}]";

                    }
                    return $"{objectOfAction} не прошел техсобеседование [{GetFormattedTime()}]";
                }
                default:
                    return "no message";
            }
        }

        public string GetLogMessage(Comment comment)
        {
            return $"{authService.LoggedUser.Login} добавил(а) комментарий \"{comment.Text}\" для человека {comment.Person.Name} {comment.Person.Surname} [{GetFormattedTime()}]";
        }


    }
}
