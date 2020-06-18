﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Interfaces
{
    public interface ILogMessageBuilder
    {
        /// <summary>
        /// Получить строку сообщения для действия создания или удаления.
        /// </summary>
        /// <param name="action">Произведенное действие.</param>
        /// <param name="objectOfAction">Объект, над которым было произведено действие.</param>
        /// <returns>Строка сообщения лога.</returns>
        string GetLogMessage(LogAction action, string objectOfAction);

        /// <summary>
        /// Получить строку сообщения для действия изменения.
        /// </summary>
        /// <param name="action">Произведенное действие.</param>
        /// <param name="objectOfAction">Объект, над которым было произведено действие.</param>
        /// <param name="changedProperty">Свойство, которое изменилось в резульате действия.</param>
        /// <param name="oldValue">Старое значение.</param>
        /// <param name="newValue">Новое значение</param>
        /// <returns>Строка сообщения лога.</returns>
        string GetLogMessage(LogAction action, string objectOfAction, string changedProperty, string oldValue, string newValue);

        /// <summary>
        /// Получить строку сообщения для действия добавления комментария.
        /// </summary>
        /// <param name="comment">Комментарий.</param>
        /// <returns>Строка сообщения лога.</returns>
        string GetLogMessage(Comment comment);
    }

    public enum LogAction
    {
        UserCreated,
        UserDeleted,
        UserChanged
        // расписать действия здесь
    }
}
