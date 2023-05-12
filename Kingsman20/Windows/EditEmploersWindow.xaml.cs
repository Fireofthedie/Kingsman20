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
    /// Логика взаимодействия для EditEmploersWindow.xaml
    /// </summary>
    public partial class EditEmploersWindow : Window
    {
        DB.Emploers editEmploers = null;

        private bool isEdit = false;
        public EditEmploersWindow()
        {
            InitializeComponent();
        }

        public EditEmploersWindow(DB.Emploers emploers)
        {
            isEdit = true;

            editEmploers = emploers;

            // Заполнение типа услуги

            CmbGenderCode.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGenderCode.DisplayMemberPath = "GenderName";

            // выгрузка изображения 


            // заполнение полей
            TbFirstNameEmploers.Text = emploers.FirstName;
            TbLastNameEmploers.Text = emploers.LastName;   
            TbLoginEmploers.Text = emploers.Login;
            TbPasswordEmploers.Text = emploers.Password;
            TbPatronymicEmploers.Text = emploers.Patronymic;


            // заполнение типа услуги
            CmbGenderCode.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.GenderCode == emploers.GenderCode).FirstOrDefault();
            CmbPost.SelectedItem = ClassHelper.EF.Context.Post.Where(i => i.ID == emploers.PostID).FirstOrDefault();

        }

        private void BtnEditEmploers_Click(object sender, RoutedEventArgs e)
        {
            editEmploers.FirstName = TbFirstNameEmploers.Text;
            editEmploers.LastName = TbLastNameEmploers.Text;
            editEmploers.Patronymic = TbPatronymicEmploers.Text;
            editEmploers.GenderCode = (CmbGenderCode.SelectedItem as DB.Gender).GenderCode;
            editEmploers.PostID = (CmbPost.SelectedItem as DB.Post).ID;
            editEmploers.Login = TbLoginEmploers.Text;
            editEmploers.Password = TbPasswordEmploers.Text;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены");

            this.Close();
        }

    }
}
