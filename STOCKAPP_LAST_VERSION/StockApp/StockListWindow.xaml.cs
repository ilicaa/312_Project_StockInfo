using System;
using System.Data.SqlClient;
using System.Windows;

namespace StockApp
{
    public partial class StockListWindow : Window
    {
        // Connection string for the database
        private string conString = "Data Source=DESKTOP-6GQR2TM;Initial Catalog=StockAppDb;Integrated Security=True";

        public StockListWindow()
        {
            InitializeComponent();
            LoadStocks();
        }

        private void LoadStocks()
        {
            // Clear any existing items in the list
            StockListBox.Items.Clear();

            // Create SQL query to fetch stocks from the database
            string query = "SELECT Name FROM Stocks"; // Replace 'Stocks' with your actual table name

            try
            {
                // Create and open a connection to the database
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    // Create the SQL command to execute
                    SqlCommand command = new SqlCommand(query, connection);

                    // Execute the query and get the data
                    SqlDataReader reader = command.ExecuteReader();

                    // Read the data and add it to the ListBox
                    while (reader.Read())
                    {
                        string stockName = reader.GetString(0); // Assuming the stock name is in the first column
                        StockListBox.Items.Add(stockName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stocks: {ex.Message}");
            }
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