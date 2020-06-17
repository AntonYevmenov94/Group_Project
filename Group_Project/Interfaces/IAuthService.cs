﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Interfaces
{
    /// <summary>
    /// Обеспечивает доступ к текущему пользователю и его роли.
    /// </summary>
    public interface IAuthService
    {
        User LoggedUser { get; set; }
        AccountRights AccountRights { get; }
    }

    public enum AccountRights
    {
        NonAuthenticated,
        Admin,
        Director,
        HR,
        MUP
    };
}
