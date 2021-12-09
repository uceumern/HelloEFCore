using System.Linq;
using System.Net.Http;
using System.Windows;

namespace GoogleBooksClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchAsync(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={searchTb.Text}";

            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            BooksResult result = System.Text.Json.JsonSerializer.Deserialize<BooksResult>(json);

            myGrid.ItemsSource = result?.items?.Select(x => x.volumeInfo).ToList();
        }
    }
}
