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

namespace Dz_6_AdoNet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users;
        public MainWindow()
        {
            InitializeComponent();
            using (UsersModel context = new UsersModel())
            {
                users = context.Users.ToList();
            }

            for (int i = 0; i < users.Count; i++)
            {
                usersListBox.Items.Add("Login: " + users[i].Login + " Password: " + users[i].Password);
            }
        }

        private void DisplayAdminChecked(object sender, RoutedEventArgs e)
        {
            usersListBox.Items.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].IsAdmin == true)
                {
                    usersListBox.Items.Add("Login: " + users[i].Login + " Password: " + users[i].Password);
                }
            }
        }

        private void DisplayAdminUnchecked(object sender, RoutedEventArgs e)
        {
            usersListBox.Items.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                usersListBox.Items.Add("Login: " + users[i].Login + " Password: " + users[i].Password);
            }
        }

        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            AddWindow aw = new AddWindow(this);
            aw.Show();
            Close();
        }

        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            using (UsersModel context = new UsersModel())
            {
                users = context.Users.ToList();
                int i = usersListBox.SelectedIndex;
                context.Users.Remove(users[i]);
                context.SaveChanges();
                users = context.Users.ToList();
            }
            usersListBox.Items.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                usersListBox.Items.Add("Login: " + users[i].Login + " Password: " + users[i].Password);
            }
        }
    }
}
