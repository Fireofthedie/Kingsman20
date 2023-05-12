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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            CmbGenderCode.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGenderCode.DisplayMemberPath = "GenderName";
            CmbGenderCode.SelectedIndex = 0;
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbFirstNameClient.Text))
            {
                MessageBox.Show("Поле Имени не заполнено"); 
                return;
            }
            if (string.IsNullOrEmpty(TbLastNameClient.Text))
            {
                MessageBox.Show("Поле Фамилии не заполнено");
                return;
            }
            if (string.IsNullOrEmpty(TbPhoneClient.Text))
            {
                MessageBox.Show("Поле Номера не заполнено");
                return;
            }
            // добавление услуги
            DB.Client newClient = new DB.Client();

            newClient.FirstName = TbFirstNameClient.Text;
            newClient.LastName = TbLastNameClient.Text;
            newClient.Patronymic = TbPatronymicClient.Text;
            newClient.Phone = TbPhoneClient.Text;
            newClient.Birthday = Convert.ToDateTime(TbBirthdayClient.Text);
            newClient.Size = Convert.ToInt32(TbSizeClient.Text);
            newClient.Login = TbLoginClient.Text;
            newClient.Password = TbPasswordClient.Text;
            newClient.GenderCode = (CmbGenderCode.SelectedItem as DB.Gender).GenderCode;
           
            ClassHelper.EF.Context.Client.Add(newClient);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Клиент добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
