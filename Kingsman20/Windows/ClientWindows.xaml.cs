using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kingsman20.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindows.xaml
    /// </summary>
    public partial class ClientWindows : Window
    {
        public ClientWindows()
        {
            InitializeComponent();
            GetListClient();
        }
        private void GetListClient()
        {
            LvService.ItemsSource = ClassHelper.EF.Context.Client.ToList();
        }
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();

            // Обновляем лист
            GetListClient();

        }

        private void BtnCngClient_Click(object sender, RoutedEventArgs e)
        {
            EditClientWindow editClientWindow = new EditClientWindow();
            editClientWindow.ShowDialog();
            var button = sender as Button;
            var client = button.DataContext as DB.Client;
            EditClientWindow addClientWindow = new EditClientWindow();
            addClientWindow.DataContext = client;

            if (button == null)
            {
                return;
            }
            GetListClient();
        }
    }
}
