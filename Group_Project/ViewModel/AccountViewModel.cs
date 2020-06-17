using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Group_Project.Utilities;

namespace Group_Project.ViewModel
{
     public class AccountViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public ICommand AddUserCommand { get; private set; }

        public ICommand EditUserCommand { get; set; }


        public AccountViewModel()
        {
            Users = new ObservableCollection<User>();
            AddUserCommand = new RelayCommand(AddUser);
            EditUserCommand = new RelayCommand(EditUser);
            Users.Add(new User { Id = 1, Login = "Serhii", Password = "111", Email = "ruban@gmail.com", RolesId = 1 });
            Users.Add(new User { Id = 2, Login = "Kliment", Password = "222", Email = "kliment.kim@gmail.com", RolesId = 2 });

        }

        private void AddUser(object obj)
        {
            MessageBox.Show("Adding new User");
        }


        private void EditUser(object obj)
        {
            //User user = obj as User;
            //MessageBox.Show($"Editing user: {user.Login}");
            if(SelectedUser!=null)
            MessageBox.Show($"Editing user: {SelectedUser.Login}");
        }
    }
}
