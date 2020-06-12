using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IContainer IoCContainer;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // регистрация компонентов в IoC контейнере
            var builder = new ContainerBuilder();

            // view
            builder.RegisterType<MainWindow>();

            IoCContainer = builder.Build();
            
            // резолвить и запустить основное окно приложения
            var appWindow = IoCContainer.Resolve<MainWindow>();
            appWindow.Show();
        }
    }
}
