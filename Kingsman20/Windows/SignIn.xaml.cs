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

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
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