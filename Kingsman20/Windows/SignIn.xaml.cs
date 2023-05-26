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
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.EF.Context.Emploers.ToList().Where(i => i.Login == TbLogin.Text && i.Password == Pbpassword.Password).
                FirstOrDefault();
            if (userAuth != null)
            {

                ClassHelper.UserDataClass.Emploers = userAuth;
                switch (userAuth.PostID)
                {
                    case 1:
                        // переход на страницу директора
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                        break;

                    case 2:
                        // переход на страницу менеджера
                        MainWindow mainWindow3 = new MainWindow();
                        mainWindow3.Show();
                        this.Close();
                        break;

                    case 3:
                        // переход на страницу партного
                        MainWindow mainWindow2 = new MainWindow();
                        mainWindow2.Show();
                        this.Close();
                        break;

                    default:
                        // переход на окно список услуг
                        ServiceWindow serviceWindow = new ServiceWindow();
                        serviceWindow.Show();
                        this.Close();

                        break;
                }
                
            }
            else
            {
                MessageBox.Show("Пользователь не существует!", "ErrorText", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnReg_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Show();
            this.Close();
        }
    }
}