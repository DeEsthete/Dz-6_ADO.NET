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

namespace Dz_6_AdoNet
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Window MainWindow;
        public AddWindow(Window window)
        {
            MainWindow = window;
            InitializeComponent();
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            using (UsersModel context = new UsersModel())
            {
                try
                {
                    User temp = new User();
                    temp.Login = loginTextBox.Text;
                    temp.Password = passwordTextBox.Text;
                    temp.IsAdmin = (bool)isAdminCheckBox.IsChecked;
                    temp.Address = addressTextBox.Text;
                    temp.Phone = phoneTextBox.Text;
                    context.Users.Add(temp);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Не все поля заполнены верно");
                }
            }
            Close();
        }

        private new void Closed()
        {
            Close();
            MainWindow.Show();
        }
    }
}
