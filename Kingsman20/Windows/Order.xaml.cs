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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
            GetCartList();
        }
        private void GetCartList()
        {
            LvCartService.ItemsSource = ClassHelper.CartService.ServiceCart;
        }
        private void BtnRemoveToOrder_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись

            ClassHelper.CartService.ServiceCart.Remove(service);

            GetCartList();
        }
        
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            CartWindow BackToCartWindow = new CartWindow();
            BackToCartWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
