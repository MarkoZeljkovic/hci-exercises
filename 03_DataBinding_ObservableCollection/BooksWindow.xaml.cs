using _03_DataBinding_ObservableCollection.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _03_DataBinding_ObservableCollection
{
    /// <summary>
    /// Interaction logic for BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Book> Books { get; set; } 

        // NOVO: SelectedBook property
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
                MessageBox.Show($"SelectedBook changed to: {value?.Title ?? "NULL"}");
            }
        }

        public BooksWindow()
        {
            InitializeComponent();

            Books = new ObservableCollection<Book>
            {
                new Book { Title = "1984", Author = "George Orwell", Year = 1949, IsRead = false },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", Year = 1932, IsRead = true },
                new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", Year = 1953, IsRead = false }
            };

            this.DataContext = this;
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var newBook = new Book
            {
                Title = $"Book #{Books.Count + 1}",
                Author = "Unknown",
                Year = 2024,
                IsRead = false
            };

            Books.Add(newBook);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
