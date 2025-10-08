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

        private readonly Databasestatements db = new Databasestatements();

        public Page1()
        {

            InitializeComponent();

        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {

            if (userPasswordPassBox.Password == userPasswordPassBox2.Password)
            {
                var user = new
                {
                    User = userUsernameTextBox.Text,
                    Password = userPasswordPassBox.Password,
                    FullName = userFullNameTextBox.Text,
                    Salt = "",
                    Email = userEmailTextBox.Text,
                };

                MessageBox.Show(db.AddNewUser(user).ToString());

            }
            else
            {
                MessageBox.Show("Eltérő jelszavak");
            }

        }
    }
}
