
using System.Windows;


namespace StockApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ViewStockList_Click(object sender, RoutedEventArgs e)
        {
            StockListWindow stockListWindow = new StockListWindow();
            stockListWindow.Show();
            this.Close();
        }

        private void AddNewStock_Click(object sender, RoutedEventArgs e)
        {
            AddStockWindow addStockWindow = new AddStockWindow();
            addStockWindow.Show();
            this.Close();
        }

        private void DeleteStock_Click(object sender, RoutedEventArgs e)
        {
            DeleteStockWindow deleteStockWindow = new DeleteStockWindow();
            deleteStockWindow.Show();
            this.Close();
        }

        private void SearchStock_Click(object sender, RoutedEventArgs e)
        {
            SearchStockWindow searchStockWindow = new SearchStockWindow();
            searchStockWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
