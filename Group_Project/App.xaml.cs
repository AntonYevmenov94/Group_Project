using Autofac;
using Group_Project.Services;
using System.Configuration;
using System.Reflection;
using System.Windows;
using Group_Project.Views;
using Group_Project.ViewModels;
using System.Data.Entity;

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
            builder.RegisterType<AppPageNavService>().As<IAppPageNavService>().SingleInstance();
            
            // view-models
            var asm = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.Name.EndsWith("ViewModel"));

            // view
            builder.RegisterType<MainWindow>();

            IoCContainer = builder.Build();
            // сохранить контейнер в статическом классе для доступа по всей программе
            IoCContainerProvider.Container = IoCContainer; 

            // регистрация компонентов в IDialogService
            RegisterViewsInDialogService();
            // установка стартовой страницы и её VM
            IoCContainer.Resolve<IAppPageNavService>().ActiveAppPage = AppPage.AuthPage;

            // резолвить и запустить основное окно приложения
            var appWindow = IoCContainer.Resolve<MainWindow>();
            appWindow.Show();


            ///////////////////////////
            // Тестовое пространство //
            ///////////////////////////

            // TODO удалить перед релизом
            // Загрузить инфо из БД, для того, чтобы насильно перестроить структуру и содержимое БД
            //IoCContainer.Resolve<IDbContextProvider>().GetDbContext().Persons.Load();

            //string s = "This is a message";
            //var vn = IoCContainer.Resolve<WindowConfirmActionDialogViewModel>(new NamedParameter("messageText", s));
            //var dlgSrv = IoCContainer.Resolve<IDialogService>();
            //if (dlgSrv.ShowModal(vn) == true)
            //    MessageBox.Show("Confirm");
        }

        private void RegisterViewsInDialogService()
        {
            using (var scope = IoCContainer.BeginLifetimeScope())
            {
                var dialogService = scope.Resolve<IDialogService>();
                dialogService.Register(typeof(DisciplineViewModel), typeof(WindowDisciplineEdit));
                //dialogService.Register(typeof(EmployeeViewModel), typeof());
                dialogService.Register(typeof(PersonViewModel), typeof(WindowPersonEdit));
                dialogService.Register(typeof(PositionViewModel), typeof(WindowPositionEdit));
                dialogService.Register(typeof(ResponseViewModel), typeof(WindowResponseEdit));
                dialogService.Register(typeof(UserViewModel), typeof(WindowUserEdit));
                dialogService.Register(typeof(VacancyViewModel), typeof(WindowVacancyEdit));
                dialogService.Register(typeof(WindowDepartmentListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowDisciplineListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowLogViewModel), typeof(WindowLog));
                dialogService.Register(typeof(WindowPositionListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowTechListViewModel), typeof(WindowGenericList));
                dialogService.Register(typeof(WindowTextLineEditViewModel), typeof(WindowTextLineEdit));
                dialogService.Register(typeof(WindowUserListViewModel), typeof(WindowUserList));
                dialogService.Register(typeof(WindowConfirmActionDialogViewModel), typeof(WindowConfirmActionDialog));
                dialogService.Register(typeof(WindowMessageViewModel), typeof(WindowMessage));
            }
        }
    }
}
