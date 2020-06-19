using Autofac;
using Group_Project.Services;
using System.Configuration;
using System.Reflection;
using System.Windows;
using Group_Project.Views;
using Group_Project.ViewModels;

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

            RegisterViewsInDialogService();

            // view-models
            var asm = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.Name.EndsWith("ViewModel"));

            // view
            builder.RegisterType<MainWindow>();

            IoCContainer = builder.Build();

            // резолвить и запустить основное окно приложения
            var appWindow = IoCContainer.Resolve<MainWindow>();
            appWindow.Show();
        }

        private void RegisterViewsInDialogService()
        {
            using (var scope = IoCContainer.BeginLifetimeScope())
            {
                var dialogService = scope.Resolve<IDialogService>();
                dialogService.Register(typeof(Discipline), typeof(WindowDisciplineEdit));
                //dialogService.Register(typeof(Employee), typeof());
                dialogService.Register(typeof(Person), typeof(WindowPersonEdit));
                dialogService.Register(typeof(Position), typeof(WindowPositionEdit));
                dialogService.Register(typeof(Response), typeof(WindowResponseEdit));
                dialogService.Register(typeof(User), typeof(WindowUserEdit));
                dialogService.Register(typeof(Vacancy), typeof(WindowVacancyEdit));
                dialogService.Register(typeof(WindowDepartmentListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowDisciplineListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowLogViewModel), typeof(WindowLog));
                dialogService.Register(typeof(WindowPositionListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowTechListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowTextLineEditViewModel), typeof(WindowTextLineEdit));
                dialogService.Register(typeof(WindowUserListViewModel), typeof(WindowUserList));
            }
        }
    }
}
