
using System.Windows;

namespace StockApp
{
    public partial class StockListWindow : Window
    {
        public StockListWindow()
        {
            InitializeComponent();
            LoadStocks();
        }

        private void LoadStocks()
        {
            // Simulating stock data
            StockListBox.Items.Add("Apple (AAPL)");
            StockListBox.Items.Add("Microsoft (MSFT)");
            StockListBox.Items.Add("Google (GOOGL)");
        }

        private void StockListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (StockListBox.SelectedItem != null)
            {
                MessageBox.Show($"Selected Stock: {StockListBox.SelectedItem}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
