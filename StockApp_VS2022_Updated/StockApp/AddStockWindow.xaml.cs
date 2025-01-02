
using System.Windows;

namespace StockApp
{
    public partial class AddStockWindow : Window
    {
        public AddStockWindow()
        {
            InitializeComponent();
        }

        private void AddStockButton_Click(object sender, RoutedEventArgs e)
        {
            string name = StockNameTextBox.Text;
            string ticker = TickerTextBox.Text;
            string price = PriceTextBox.Text;
            string category = CategoryComboBox.Text;

            MessageBox.Show($"Stock Added: {name}, {ticker}, {price}, {category}");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
