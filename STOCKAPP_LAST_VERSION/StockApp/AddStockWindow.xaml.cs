using System.Windows;
using System.Data.SqlClient;
using System;

namespace StockApp
{
    public partial class AddStockWindow : Window
    {
        public AddStockWindow()
        {
            InitializeComponent();
        }

        public SqlConnection data_conc = new SqlConnection("Data Source=192.168.1.1,1433; Network Library=DBMSSOCN; Initial Catalog=StockAppDb;User ID=admin;Password=1;Tcp");


        private void AddStockButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve input values from the UI
            string name = StockNameTextBox.Text;
            string ticker = TickerTextBox.Text;
            string price = PriceTextBox.Text;
            string category = CategoryComboBox.Text;

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ticker) ||
                string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please fill in all fields before adding a stock.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Database logic to save the stock
            try
            {
                using (SqlConnection connection = new SqlConnection(data_conc.ConnectionString)) // Temporary SqlConnection
                {
                    connection.Open();

                    // SQL query to insert the stock data
                    string query = "INSERT INTO Stocks (Name, Ticker, Price, Category) VALUES (@Name, @Ticker, @Price, @Category)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Ticker", ticker);
                        command.Parameters.AddWithValue("@Price", decimal.Parse(price));
                        command.Parameters.AddWithValue("@Category", category);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Stock '{name}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearFields(); // Optional: Clear the input fields
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the stock. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid price format. Please enter a numeric value.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearFields()
        {
            StockNameTextBox.Clear();
            TickerTextBox.Clear();
            PriceTextBox.Clear();
            CategoryComboBox.SelectedIndex = -1;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
