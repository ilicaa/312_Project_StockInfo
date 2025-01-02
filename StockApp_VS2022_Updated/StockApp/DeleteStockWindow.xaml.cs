using System;
using System.Windows;
using System.Windows.Controls;

namespace StockApp
{

    public partial class DeleteStockWindow : Window
    {
        public DeleteStockWindow()
        {
            InitializeComponent();
        }

        private void StockNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine($"Text changed: {StockNameTextBox.Text}");
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string stockSymbol = StockNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(stockSymbol))
            {
                MessageBox.Show("Please enter a stock name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isDeleted = DeleteStock(stockSymbol);

            if (isDeleted)
            {
                MessageBox.Show($"Stock with name '{stockSymbol}' has been deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                return; 
            }
            else
            {
                MessageBox.Show($"Failed to delete stock with name '{stockSymbol}'. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BackToDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }


        private bool DeleteStock(string stockSymbol)
        {
            try
            {
                Console.WriteLine($"Deleting stock: {stockSymbol}");
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting stock: {ex.Message}");
                return false;
            }
        }
    }
}

