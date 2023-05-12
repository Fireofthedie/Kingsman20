using Microsoft.Win32;
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
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {

        DB.Service editService = null;

        private string pathImage = null;
        private bool isEdit = false;

        public EditServiceWindow()
        {
            InitializeComponent();
            isEdit = false;
            CmbTypeService.ItemsSource = ClassHelper.EF.Context.CategoryOfService.ToList();
            CmbTypeService.DisplayMemberPath = "CategoryName";
            CmbTypeService.SelectedIndex = 0;
        }
        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }
        public EditServiceWindow(DB.Service service)
        {
           

            isEdit = true;

            editService = service;

            // Заполнение типа услуги

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.CategoryOfService.ToList();
            CmbTypeService.DisplayMemberPath = "TypeName";

            // выгрузка изображения 
            ImgImageService.Source = new BitmapImage(new Uri(service.Photo));

            // заполнение полей
            TbNameService.Text = service.Title;
            TbDiscService.Text = service.Description;
            TbPriceService.Text = Convert.ToString(service.Cost);

            // заполнение типа услуги
            CmbTypeService.SelectedItem = ClassHelper.EF.Context.CategoryOfService.Where(i => i.ID == service.CategoryID).FirstOrDefault();

        }

        private void BtnEditService_Click(object sender, RoutedEventArgs e)
        {
            // валидация

            editService.Title = TbNameService.Text;
            editService.Description = TbDiscService.Text;
            editService.Cost = Convert.ToDecimal(TbPriceService.Text);
            editService.CategoryID = (CmbTypeService.SelectedItem as DB.CategoryOfService).ID;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены");

            this.Close();
        }
    }
}