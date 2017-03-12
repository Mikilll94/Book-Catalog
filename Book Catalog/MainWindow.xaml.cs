using HomeLibrary;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Book_Catalog
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> booksList = MyBookCollection.GetMyCollection();

        public MainWindow()
        {
            InitializeComponent();
            BooksList.ItemsSource = booksList;
            BookFormats.ItemsSource = Enum.GetValues(typeof(BookFormat));
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            booksList.Add(new Book(1)
            {
                Author = Author_txtbox.Text,
                Format = (BookFormat)BookFormats.SelectedItem,
                IsRead = (bool)IsRead_checkbox.IsChecked,
                Title = Title_txtbox.Text,
                Year = int.Parse(Year_txtbox.Text)
            });
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            Author_txtbox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            BookFormats.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
            IsRead_checkbox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            Title_txtbox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            Year_txtbox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            booksList.RemoveAt(BooksList.SelectedIndex);
        }
    }
}
