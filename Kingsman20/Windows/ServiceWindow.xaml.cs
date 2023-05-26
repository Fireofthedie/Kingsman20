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
using Kingsman20.ClassHelper;

namespace Kingsman20.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
            GetListService();
            if (ClassHelper.UserDataClass.Emploers.PostID == 2)
            {
                BtnAddService.Visibility = Visibility.Collapsed;
            }
            if (ClassHelper.UserDataClass.Emploers.PostID == 1)
            {
                GoToCart.Visibility = Visibility.Collapsed;                
            }

        }

        private void GetListService()
        {
            LvService.ItemsSource = ClassHelper.EF.Context.Service.ToList();
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new AddServiceWindow();
            addServiceWindow.ShowDialog();

            // Обновляем лист
            GetListService();
        }
        private void BtnCngService_Click(object sender, RoutedEventArgs e)
        {                     
            EditServiceWindow editServiceWindow = new EditServiceWindow();
            editServiceWindow.ShowDialog();
            var button = sender as Button;
            var service = button.DataContext as DB.Service;
            EditServiceWindow addServiceWindow = new EditServiceWindow();
            addServiceWindow.DataContext = service;

            if (button == null)
            {
                return;
            }
            GetListService();
        }

        private void BtnAddCartService_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись


            CartService.ServiceCart.Add(service);

            MessageBox.Show($"Услуга {service.Title} добавлена в корзину!");
        }

        private void GoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow GoToCartWindow = new CartWindow();
            GoToCartWindow.ShowDialog();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}