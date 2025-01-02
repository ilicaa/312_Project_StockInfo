using System;
using System.Data.SqlClient;
using System.Windows;

namespace StockApp
{
    public partial class SearchStockWindow : Window
    {
        // Connection string for the database
        private string conString = "Data Source=DESKTOP-6GQR2TM;Initial Catalog=StockAppDb;Integrated Security=True";

        public SearchStockWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextBox.Text;
            MessageBox.Show($"Searching for: {query}");

            // SQL query to search for stocks by name
            string sqlQuery = "SELECT Name, Ticker, Price FROM Stocks WHERE Name LIKE @SearchQuery";

            try
            {
                // Create and open a connection to the database
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    // Create the SQL command to execute
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    // Use parameterized query to avoid SQL injection
                    command.Parameters.AddWithValue("@SearchQuery", "%" + query + "%");

                    // Execute the query and get the data
                    SqlDataReader reader = command.ExecuteReader();

                    // Create a list to store the search results
                    var searchResults = new System.Collections.Generic.List<object>();

                    // Read the data and add it to the search results list
                    while (reader.Read())
                    {
                        string stockName = reader.GetString(0);
                        string ticker = reader.GetString(1);
                        string price = reader.GetDecimal(2).ToString("F2"); // Assuming the price is a decimal

                        searchResults.Add(new { Name = stockName, Ticker = ticker, Price = price });
                    }

                    // Set the DataGrid's items source to the search results
                    SearchResultsDataGrid.ItemsSource = searchResults;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for stock: {ex.Message}");
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
