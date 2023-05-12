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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        DB.Client editClient = null;

        private bool isEdit = false;
        public EditClientWindow()
        {
            InitializeComponent();
        }

        public EditClientWindow(DB.Client client)
        {
            isEdit = true;

            editClient = client;

            // Заполнение типа услуги

            CmbGenderCode.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGenderCode.DisplayMemberPath = "GenderName";

            // выгрузка изображения 


            // заполнение полей
            TbFirstNameClient.Text = client.FirstName;
            TbLastNameClient.Text = client.LastName;
            TbPhoneClient.Text = client.Phone;
            TbBirthdayClient.Text = Convert.ToString(client.Birthday);
            TbSizeClient.Text = Convert.ToString(client.Size);
            TbLoginClient.Text = client.Login;
            TbPasswordClient.Text = client.Password;
            TbPatronymicClient.Text = client.Patronymic;


            // заполнение типа услуги
            CmbGenderCode.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.GenderCode == client.GenderCode).FirstOrDefault();

        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            editClient.FirstName = TbFirstNameClient.Text;
            editClient.LastName = TbLastNameClient.Text;
            editClient.Patronymic = TbPatronymicClient.Text;
            editClient.GenderCode = (CmbGenderCode.SelectedItem as DB.Gender).GenderCode;
            editClient.Phone = TbPhoneClient.Text;
            editClient.Birthday = Convert.ToDateTime(TbBirthdayClient.Text);
            editClient.Size = Convert.ToInt32(TbSizeClient.Text);
            editClient.Login = TbLoginClient.Text;
            editClient.Password = TbPasswordClient.Text;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены");

            this.Close();
        }
    }
}
