using lab1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;



namespace lab1.ViewModel
{
  
    public class UsersBookViewModel : INotifyPropertyChanged
    {



        private ObservableCollection<UserBook> userBook;

        public ObservableCollection<UserBook> UserBooks
        {
            get { return userBook; }
            set
            {
                userBook = value;
                OnPropertyChanged();
            }
        }
        private ICollectionView UserBooksCollectionView;
        private User selectedUser;
        public User SelectedUser
        {
            get { return Array.Array.selectetUSer; }
        }
        private Book selectedBook;
        public Book SelectedBook
        {
            get { return Array.Array.selectetBOok; }

        }


        private int inputValue;
        public int InputValue
        {
            get { return inputValue; }
            set
            {
                inputValue = value; 
                OnPropertyChanged("InputValue");
            }
        }

        public UsersBookViewModel()
        {
            
            userBook = new ObservableCollection<UserBook>(lab1.Array.Array.userBook);

            UserBooksCollectionView= CollectionViewSource.GetDefaultView(userBook);

        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      
                      if (SelectedUser != null && SelectedBook != null && InputValue > 0 && SelectedBook.Count >= InputValue)
                      {
                          var userBookRecord = userBook.FirstOrDefault(record => record.User == SelectedUser && record.Book == SelectedBook);
                          if (userBookRecord != null)
                          {
                              SelectedBook.Count -= InputValue;
                              userBookRecord.Quantity += InputValue;
                          }
                          else
                          {
                              SelectedBook.Count -= InputValue;
                              userBook.Add(new UserBook(SelectedUser, SelectedBook, InputValue));
                          }

                          ShowSuccessMessage(SelectedUser.FullName, SelectedBook.Title, InputValue, "выдана");
                      }
                      else
                      {
                          MessageBox.Show("Упс. Похоже, вы не можете выдать книгу. Проверьте корректность введенных значений.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                      UpdateUI();
                  }
                  ));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      if (SelectedUser != null && SelectedBook != null && InputValue > 0)
                      {
                          var userBookRecord = userBook.FirstOrDefault(record => record.User == SelectedUser && record.Book == SelectedBook);
                          if (userBookRecord != null && InputValue <= userBookRecord.Quantity)
                          {
                              SelectedBook.Count += InputValue;
                              userBookRecord.Quantity -= InputValue;

                              if (userBookRecord.Quantity <= 0)
                              {
                                  userBook.Remove(userBookRecord);
                              }
                              ShowSuccessMessage(SelectedUser.FullName, SelectedBook.Title, InputValue, "возвращена");
                          }
                          else
                          {
                              MessageBox.Show("Вы не можете вернуть больше книг, чем брали, или данный пользователь не брал данную книгу.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                          }
                      }
                      else
                      {
                          MessageBox.Show("Упс. Похоже, вы не можете выполнить возврат книги. Проверьте корректность введенных значений.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                      UpdateUI();
                  }
                 ));
            }
        }


        private void ShowSuccessMessage(string userName, string bookTitle, int quantity, string action)
        {
            StringBuilder userBooksStringBuilder = new StringBuilder("Список выданных книг:\n");
            foreach (var record in userBook)
            {
                userBooksStringBuilder.AppendLine($"Пользователь: {record.User.FullName}, Книга: {record.Book.Title}, Количество: {record.Quantity} шт.");
            }

            MessageBox.Show($"Книга \"{bookTitle}\" успешно {action} пользователем {userName}.\n\n{userBooksStringBuilder}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateUI()
        {
            OnPropertyChanged("UserBooks");
            OnPropertyChanged("Books");
            OnPropertyChanged("SelectedBook");
            OnPropertyChanged("SelectedUser");
            
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}