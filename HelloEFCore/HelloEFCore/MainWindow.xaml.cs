using HelloEFCore.Data;
using System.Linq;
using System.Windows;

namespace HelloEFCore
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

        private void LoadAll(object sender, RoutedEventArgs e)
        {
            var context = new EFContext();
            context.Database.EnsureCreated();

            dataGrid.ItemsSource = context.Employees.ToList();
        }
    }
}
