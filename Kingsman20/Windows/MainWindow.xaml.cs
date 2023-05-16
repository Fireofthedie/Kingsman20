using Kingsman20.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kingsman20
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnEmploersWindow_Click(object sender, RoutedEventArgs e)
        {
            EmploersWindow emploersWindow = new EmploersWindow();
            emploersWindow.Show();
            this.Close();
        }

        private void BtnClientWindow_Click(object sender, RoutedEventArgs e)
        {
            ClientWindows clientWindow = new ClientWindows();
            clientWindow.Show();
            this.Close();
        }

        private void BtnServiceWindow_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();
        }

        private void BtnReportWindow_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
            this.Close();
        }
    }
}
