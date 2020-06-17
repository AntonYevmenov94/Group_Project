﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.ViewModels
{
    public class EmployeeViewModel : BaseDialogViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate EmployeeViewModel Factory(Employee employee);


        public EmployeeViewModel(
            IAuthService accountService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Employee employee)
            : base(accountService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
