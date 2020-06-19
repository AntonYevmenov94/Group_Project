using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления вкладки на главной странице <see cref="Views.MainPage"/>,
    /// представляющей список <see cref="Vacancy"/> и функционал CRUD операций над элементами списка.
    /// Привязывается к <see cref="Views.TabVacancies"/>
    /// </summary>
    public class TabVacanciesViewModel : BaseViewModel
    {
        public Vacancy SelectedVacancy { get; set; }
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Technology> Technologies { get; set; }

        public ICommand RefreshCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand ApplyFilterCommand { get; set; }
        public ICommand ResetFilterCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand EditCommand { get; set; }



        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate TabVacanciesViewModel Factory();

        public TabVacanciesViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
