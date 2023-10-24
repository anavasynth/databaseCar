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

namespace Database
{
    /// <summary>
    /// Логика взаимодействия для GuideWindow.xaml
    /// </summary>
    public partial class GuideWindow : Window
    {
        public GuideWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void HowToAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ЗДАРОВА НЄФАР");
        }

        private void HowToShowData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HowToEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HowToDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HoToUseAddFunctions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
