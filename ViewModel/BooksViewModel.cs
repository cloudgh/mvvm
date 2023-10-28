using lab1.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using lab1.Array;

namespace lab1.ViewModel
{
    public class BooksViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> books;
        private string authorFilterText;
        private string titleFilterText;
        private ICollectionView booksCollectionView;

        public BooksViewModel()
        {
            books = new ObservableCollection<Book>(lab1.Array.Array.books);
       

            booksCollectionView = CollectionViewSource.GetDefaultView(books);
        }
      
        private Book selectedBook;
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                Array.Array.selectetBOok = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged();
            }
        }

        public string AuthorFilterText
        {
            get { return authorFilterText; }
            set
            {
                authorFilterText = value;
                OnPropertyChanged();
                FilterBooksByAuthor();
            }
        }

        public string TitleFilterText
        {
            get { return titleFilterText; }
            set
            {
                titleFilterText = value;
                OnPropertyChanged();
                FilterBooksByTitle();
            }
        }

        private void FilterBooksByAuthor()
        {
            booksCollectionView.Filter = item =>
            {
                if (item is Book book)
                {
                    return book.Author.IndexOf(authorFilterText, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            };
        }

        private void FilterBooksByTitle()
        {
            booksCollectionView.Filter = item =>
            {
                if (item is Book book)
                {
                    return book.Title.IndexOf(titleFilterText, StringComparison.OrdinalIgnoreCase) >= 0;
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