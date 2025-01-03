using System;
using System.Data.SqlClient;
using System.Windows;

namespace StockApp
{
    public partial class StockListWindow : Window
    {
        public SqlConnection data_conc = new SqlConnection("Data Source=192.168.1.1,1433; Network Library=DBMSSOCN; Initial Catalog=StockAppDb;User ID=admin;Password=1;Tcp");

        public StockListWindow()
        {
            InitializeComponent();
            LoadStocks();
        }

        private void LoadStocks()
        {
            LoadStocks(data_conc);
        }

        private void LoadStocks(SqlConnection data_connection)
        {
            try
            {
                data_connection.Open(); // Baðlantýyý açýn

                string query = "SELECT Name FROM Stocks"; // Replace 'Stocks' with your actual table name
                SqlCommand command = new SqlCommand(query, data_connection);
                SqlDataReader reader = command.ExecuteReader();

                StockListBox.Items.Clear();
                while (reader.Read())
                {
                    string stockName = reader.GetString(0); // Assuming the stock name is in the first column
                    StockListBox.Items.Add(stockName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stocks: {ex.Message}");
            }
            finally
            {
                data_connection.Close(); // Baðlantýyý kapatýn
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