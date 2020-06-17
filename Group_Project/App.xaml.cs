using Autofac;
using System.Configuration;
using System.Windows;
using Group_Project.Services;

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

            string dbConnStr = ConfigurationManager.ConnectionStrings["job"].ConnectionString;

            // регистрация компонентов в IoC контейнере
            var builder = new ContainerBuilder();

            // сервисы
            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.Register(c => new DbContextProvider(dbConnStr)).As<IDbContextProvider>();
            builder.RegisterType<WindowsDialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<LogMessageBuilder>().As<ILogMessageBuilder>();

            // view
            builder.RegisterType<MainWindow>();

            IoCContainer = builder.Build();
            
            // резолвить и запустить основное окно приложения
            var appWindow = IoCContainer.Resolve<MainWindow>();
            appWindow.Show();
        }
    }
}
