using Kingsman20.DB;
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
    /// Логика взаимодействия для EmploersWindow.xaml
    /// </summary>
    public partial class EmploersWindow : Window
    {
        public EmploersWindow()
        {
            InitializeComponent();
            GetListEmploers();
        }

        private void GetListEmploers()
        {
            LvEmploers.ItemsSource = ClassHelper.EF.Context.Emploers.ToList();
        }

        private void BtnAddEmploers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
