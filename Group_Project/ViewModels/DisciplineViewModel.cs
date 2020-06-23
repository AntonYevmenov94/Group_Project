using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="Discipline"/>.
    /// Привязывается к окну <see cref="Views.WindowDisciplineEdit"/>
    /// </summary>
    public class DisciplineViewModel : BaseDialogViewModel
    {
        public Discipline InternalDiscipline { get; set; }
        public ObservableCollection<Technology> InternDisciplineTechnologies { get; set; }
        public ObservableCollection<Technology> AllTechnologies { get; set; }
        public Technology SelectedTech { get; set; }


        public ICommand CmdAddTech { get; set; }
        public ICommand CmdRemoveTech { get; set; }
        public ICommand CmdSaveEntityChanges { get; set; }
        public ICommand CmdDismissEntityChanges { get; set; }
        


        #region Constructor

        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate DisciplineViewModel Factory(Discipline discipline);
        
        public DisciplineViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Discipline discipline)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            var db = dbContextProvider.GetDbContext();
            db.Technologies.Load();
            db.Disciplines.Load();

            AllTechnologies = db.Technologies.Local;
            var dbSearchRes = db.Disciplines.Find(discipline.Id);
            InternalDiscipline = dbSearchRes ?? discipline;
            InternDisciplineTechnologies = new ObservableCollection<Technology>(InternalDiscipline.Technologies);

            CmdAddTech = new RelayCommand(
                new Action<object>(AddTech),
                (obj) => { return SelectedTech != null; });
            CmdRemoveTech = new RelayCommand(new Action<object>(RemoveTech));
            CmdSaveEntityChanges = new RelayCommand(
                new Action<object>(SaveEntityChanges),
                (obj) => { return true; }); // TODO проверка InternalDiscipline на наличие ошибок
            CmdDismissEntityChanges = new RelayCommand(new Action<object>(DismissEntityChanges));
        }
        #endregion


        #region Commands implementation

        private void AddTech(object obj)
        {
            if (SelectedTech == null)
                return;

            if (InternDisciplineTechnologies.Contains(SelectedTech))
                return;

            InternDisciplineTechnologies.Add(SelectedTech);
        }

        private void RemoveTech(object obj)
        {
            if (obj == null)
                return;

            var tech = (Technology)obj;
            InternDisciplineTechnologies.Remove(tech);
        }

        private void SaveEntityChanges(object obj)
        {
            InternalDiscipline.Technologies = new HashSet<Technology>(InternDisciplineTechnologies);
            var db = dbContextProvider.GetDbContext();
            if (InternalDiscipline.Id == 0)
            {
                db.Disciplines.Add(InternalDiscipline);
                db.SaveChanges();
            }
            else
            {
                db.SaveChanges();
            }
        }

        private void DismissEntityChanges(object obj)
        {

        }
        #endregion
    }
}
