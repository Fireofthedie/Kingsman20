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
    /// Логика взаимодействия для AddEmploersWindow.xaml
    /// </summary>
    public partial class AddEmploersWindow : Window
    {
        public AddEmploersWindow()
        {
            InitializeComponent();
            CmbGenderCode.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGenderCode.DisplayMemberPath = "GenderName";
            CmbGenderCode.SelectedIndex = 0;
        }

        private void BtnAddEmploers_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbFirstNameEmploers.Text))
            {
                MessageBox.Show("Поле Имени не заполнено");
                return;
            }
            if (string.IsNullOrEmpty(TbLastNameEmploers.Text))
            {
                MessageBox.Show("Поле Фамилии не заполнено");
                return;
            }
            // добавление услуги
            DB.Emploers newEmploers = new DB.Emploers();

            newEmploers.FirstName = TbFirstNameEmploers.Text;
            newEmploers.LastName = TbLastNameEmploers.Text;
            newEmploers.Patronymic = TbPatronymicEmploers.Text;
            newEmploers.PostID = (CmbPost.SelectedItem as DB.Post).ID;
            newEmploers.Login = TbLoginEmploers.Text;
            newEmploers.Password = TbPasswordEmploers.Text;
            newEmploers.GenderCode = (CmbGenderCode.SelectedItem as DB.Gender).GenderCode;

            ClassHelper.EF.Context.Emploers.Add(newEmploers);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Клиент добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
