using InventoryCalc.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        
        private void dataGrid_Loaded (object sender, RoutedEventArgs e)
        {

            string pathToFile = @"C:\Users\Gin\source\repos\InventoryCalc\InventoryCalc\Items.json";
            string itemsList = fileRead(pathToFile);

            List<ItemsListModel> items = new List<ItemsListModel>();
            items = JsonSerializer.Deserialize<List<ItemsListModel>>(itemsList)!;
            dataGridItemList.ItemsSource = items;
        }

        private string fileRead (string path)
        {
            try
            {
                //string fileName = @"sC:\Users\Gin\source\repos\InventoryCalc\InventoryCalc\Items.json";
                string jsonString = File.ReadAllText(path);
                return jsonString;
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
                return null;
            }
        }
    }
}