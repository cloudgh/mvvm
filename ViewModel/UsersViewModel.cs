using lab1.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using lab1.Array;

namespace lab1.ViewModel
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> users;
        private string nameFilterText;
        private string lastNameFilterText;
        private ICollectionView usersCollectionView;

        public UsersViewModel()
        {
            users = new ObservableCollection<User>(lab1.Array.Array.users);
           
          
            usersCollectionView = CollectionViewSource.GetDefaultView(users);
           
        }
        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                Array.Array.selectetUSer = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }

        public string NameFilterText
        {
            get { return nameFilterText; }
            set
            {
                nameFilterText = value;
                OnPropertyChanged();
                FilterUsersByName();
            }
        }

        public string LastNameFilterText
        {
            get { return lastNameFilterText; }
            set
            {
                lastNameFilterText = value;
                OnPropertyChanged();
                FilterUsersByLastName();
            }
        }

        private void FilterUsersByName()
        {
            usersCollectionView.Filter = item =>
            {
                if (item is User user)
                {
                    return user.Name.IndexOf(nameFilterText, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            };
        }

        private void FilterUsersByLastName()
        {
            usersCollectionView.Filter = item =>
            {
                if (item is User user)
                {
                    return user.Lastname.IndexOf(lastNameFilterText, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
