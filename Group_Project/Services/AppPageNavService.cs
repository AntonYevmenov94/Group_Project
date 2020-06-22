using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group_Project;
using Group_Project.ViewModels;

namespace Group_Project.Services
{
    public class AppPageNavService : INotifyPropertyChanged, IAppPageNavService
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Private members

        private AppPage activeAppPage;
        private AuthPageViewModel.Factory authPageVmFactory;
        private MainPageViewModel.Factory mainPageVmFactory;
        #endregion


        public AppPage ActiveAppPage
        {
            get => activeAppPage;
            set
            {
                activeAppPage = value;
                SelectPageViewModel();
            }
        }

        public BaseViewModel ActivePageViewModel { get; private set; }


        public AppPageNavService(
            AuthPageViewModel.Factory authPageVmFactory,
            MainPageViewModel.Factory mainPageVmFactory)
        {
            this.authPageVmFactory = authPageVmFactory;
            this.mainPageVmFactory = mainPageVmFactory;
        }


        private void SelectPageViewModel()
        {
            switch (activeAppPage)
            {
                case AppPage.AuthPage:
                    ActivePageViewModel = authPageVmFactory.Invoke();
                    break;
                case AppPage.MainPage:
                    ActivePageViewModel = mainPageVmFactory.Invoke();
                    break;
            }
        }


    }
}

namespace Group_Project
{
    public enum AppPage
    {
        Blank,
        AuthPage,
        MainPage
    }
}

