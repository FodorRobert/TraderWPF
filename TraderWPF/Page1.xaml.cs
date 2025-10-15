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

namespace TraderWPF
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        private readonly Databasestatements _databaseStatements = new Databasestatements();
        private readonly MainWindow _mainWindow;

        public Page1(MainWindow mainWindow)
        {

            InitializeComponent();
            _mainWindow = mainWindow;

        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {

            var user = new
            {

                Name = userUsernameTextBox.Text,
                Pass = userPasswordPassBox.Password,

            };

            MessageBox.Show(_databaseStatements.LogInUser(user).ToString());
            
        }

        private void regLink_Click(object sender, RoutedEventArgs e)
        {

            _mainWindow.Startwindow.Navigate(new Page2(_mainWindow));

        }
    }
}
