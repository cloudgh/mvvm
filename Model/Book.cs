using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1.Model
{
    public class Book : INotifyPropertyChanged
    {
        public Book(int id, string author, string title, DateTime releaseDate, int count)
        {
            Id = id;
            Author = author;
            Title = title;
            ReleaseDate = releaseDate;
            Count = count;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
       
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        public string FullBook => $"{Title} .Books left: {Count}";

        public event PropertyChangedEventHandler? PropertyChanged;
    }
   

}