
using System.Windows;

namespace StockApp
{
    public partial class SearchStockWindow : Window
    {
        public SearchStockWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextBox.Text;
            MessageBox.Show($"Searching for: {query}");
            // Simulate search results
            SearchResultsDataGrid.ItemsSource = new[]
            {
                new { Name = "Apple", Ticker = "AAPL", Price = "145" },
                new { Name = "Microsoft", Ticker = "MSFT", Price = "300" }
            };
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
