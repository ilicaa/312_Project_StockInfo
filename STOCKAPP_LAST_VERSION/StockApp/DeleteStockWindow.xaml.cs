using System;
using System.Data.SqlClient;
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

        public SqlConnection data_conc = new SqlConnection("Data Source=192.168.1.1,1433; Network Library=DBMSSOCN; Initial Catalog=StockAppDb;User ID=admin;Password=1;Tcp");


        private void StockNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine($"Text changed: {StockNameTextBox.Text}");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string stockName = StockNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(stockName))
            {
                MessageBox.Show("Please enter a stock name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isDeleted = DeleteStock(stockName);

            if (isDeleted)
            {
                MessageBox.Show($"Stock with name '{stockName}' has been deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                StockNameTextBox.Clear(); // Clear the input field
            }
            else
            {
                MessageBox.Show($"Failed to delete stock with name '{stockName}'. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private bool DeleteStock(string stockName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(data_conc.ConnectionString)) // Temporary SqlConnection
                {
                    connection.Open();

                    // SQL query to delete the stock by name
                    string query = "DELETE FROM Stocks WHERE Name = @Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@Name", stockName);

                        // Execute the query and check rows affected
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0; // Return true if a row was deleted
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
