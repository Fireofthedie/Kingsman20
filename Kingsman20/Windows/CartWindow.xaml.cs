using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetListServise();
        }       

        private void GetListServise()
        {
            ObservableCollection<DB.Service> listCart = new ObservableCollection<DB.Service>(ClassHelper.CartService.ServiceCart);
            LvCartService.ItemsSource = listCart;
        }

        private void BtnRemoveToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись

            ClassHelper.CartService.ServiceCart.Remove(service);

            GetListServise();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow GoToService = new ServiceWindow();
            GoToService.ShowDialog();
        }

        private void BtnGoToOrder_Click(object sender, RoutedEventArgs e)
        {
            // покупка
            EF.Context.Order.Add(new DB.Order
            {
                ClientID = 1,
                EmploersID = UserDataClass.Emploers.ID,
                DateTime = DateTime.Now,
            }
            );

            foreach (var item in ClassHelper.CartService.ServiceCart)
            {
                DB.OrderService orderService = new DB.OrderService();
                orderService.OrderID = 1;
                orderService.ServiceID = item.ID;
                orderService.Quantity = 1;

                EF.Context.OrderService.Add(orderService);
                EF.Context.SaveChanges();
            }

            EF.Context.SaveChanges();
            // переход на главную

            this.Close();
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {         
            var button = sender as Button;
            if (button == null)
            {
                return;
            }            

            var Service = button.DataContext as DB.Service;

            if (Service.Count < 20)
            {
                Service.Count++;
                GetListServise();
            }
        }
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var Service = button.DataContext as DB.Service;

            if (Service.Count > 1)
            {
                Service.Count--;
                GetListServise();
            }

        }

        
    }
}