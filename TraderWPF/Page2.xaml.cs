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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private readonly Databasestatements db = new Databasestatements();
        private readonly MainWindow _mainWindow;

        public Page2(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (userPasswordPassBox.Password == userPasswordPassBox2.Password)
            {
                var user = new
                {
                    UserName = userUsernameTextBox.Text,
                    UserPassword = userPasswordPassBox.Password,
                    Fullname = userFullNameTextBox.Text,
                    Salt = "",
                    Email = userEmailTextBox.Text
                };

                MessageBox.Show(db.AddNewUser(user).ToString());
                _mainWindow.Startwindow.Navigate(new Page1(_mainWindow));
            }
            else
            {
                MessageBox.Show("Eltérő jelszavak");
            }
        }
    }
}
