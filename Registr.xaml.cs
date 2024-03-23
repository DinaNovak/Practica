using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var pass = PasswordBox.Text;
            var email = EmailBox.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login== login);
            if ((!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(mail\.ru||gmail\.com||yandex\.ru)$" )))
            {
                Mebox.Text = "";
                Mebox.Text = "Неверный адрес почты";
            }
            if (user_exists is not null)
            {
                Mebox.Text = "";
                Mebox.Text = "Такой пользователь уже в клубе крутышек";

            }
            if (PasswordBox.Text.Contains('.') == false|| PasswordBox.Text.Contains('+') ==false|| PasswordBox.Text.Contains('-') == false || PasswordBox.Text.Contains('$') == false);
            {
                Mebox.Text = "";
                Mebox.Text="Добавьте обязательные знаки!";
            }
            var user = new User {  Login = login, Password = pass, Email = email};
            context.Users.Add(user);    
            context.SaveChanges();
            Mebox.Text = "";
            Mebox.Text="Welvome to the club, buddy";

         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow zareg = new MainWindow();
            zareg.Show();
        }
    }
}
