using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Group_Project.Services
{
    internal class WindowsDialogService : IDialogService
    {
        private Dictionary<Type, Type> viewModelToViewRelations = new Dictionary<Type, Type>();

        public void Register(Type viewModel, Type window)
        {
            if (!viewModel.IsSubclassOf(typeof(BaseViewModel)))
                throw new ArgumentException($"Parameter '{viewModel}' should be inherited from {typeof(BaseViewModel)}.");
            if (!viewModel.IsSubclassOf(typeof(BaseViewModel)))
                throw new ArgumentException($"Parameter '{window}' should be inherited from {typeof(Window)}.");
            if (viewModelToViewRelations.ContainsKey(viewModel))
                throw new ArgumentException($"View-Model '{viewModel}' is already registered.");

            viewModelToViewRelations.Add(viewModel, window);
        }

        public string OpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != true)
            {
                return null;
            }

            return ofd.FileName;
        }

        public string SaveFileDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != true)
            {
                return null;
            }

            return sfd.FileName;
        }

        public void Show(BaseDialogViewModel dialogVm, Action onConfirm = null, Action onDismiss = null)
        {
            var vmType = dialogVm.GetType();
            if (!viewModelToViewRelations.ContainsKey(vmType))
                throw new ArgumentException($"View-Model '{dialogVm}' is not registered.");

            if (onConfirm != null)
                dialogVm.OnConfirm = onConfirm;
            if (onDismiss != null)
                dialogVm.OnDismiss = onDismiss;

            var winType = viewModelToViewRelations[dialogVm.GetType()];
            var dialogWin = (Window)Activator.CreateInstance(winType);
            dialogWin.DataContext = dialogVm;
            dialogWin.Show();
        }

        public bool? ShowModal(BaseDialogViewModel dialogVm, Action onConfirm = null, Action onDismiss = null)
        {
            var vmType = dialogVm.GetType();
            if (!viewModelToViewRelations.ContainsKey(vmType))
                throw new ArgumentException($"View-Model '{dialogVm}' is not registered.");

            if (onConfirm != null)
                dialogVm.OnConfirm = onConfirm;
            if (onDismiss != null)
                dialogVm.OnDismiss = onDismiss;

            var winType = viewModelToViewRelations[dialogVm.GetType()];
            var dialogWin = (Window)Activator.CreateInstance(winType);
            dialogWin.DataContext = dialogVm;

            var dialogResult = dialogWin.ShowDialog();
            return dialogResult;
        }

    }
}
