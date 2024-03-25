using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            var pass = PasswordBox1.Text;
            var email = EmailBox.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login && x.Password == pass);
            
            if ((!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(mail\.ru||gmail\.com||yandex\.ru)$" )))
            {
                Mebox.Text = "";
                Mebox.Text = "Неверный адрес почты";
                error1.Visibility = Visibility.Visible;
            }
            else if (((!Regex.IsMatch(pass, @"[!,&%+_]"))))
            {
                error1.Visibility= Visibility.Collapsed;
                error3.Visibility = Visibility.Visible;
                Mebox.Text = "";
                Mebox.Text="Добавьте обязательные знаки!";
            }
            
            else if (PasswordBox1.Text.Length <8)
            {
                error1.Visibility = Visibility.Collapsed;
                error3.Visibility = Visibility.Collapsed;
               error2.Visibility = Visibility.Visible;
               Mebox.Text = "";
               Mebox.Text = "Данный пароль является ненадежным!";         
            }
            else if (PasswordBox1.Text !=PasswordBox2.Text)
            {
                error1.Visibility = Visibility.Collapsed;
                error2.Visibility = Visibility.Collapsed;
                error4.Visibility = Visibility.Visible;
                Mebox.Text = "";
                Mebox.Text = "Пароли не совпадают";
            }
           
            
            else if (user_exists is not null)
            {
                error4.Visibility = Visibility.Collapsed;
                Mebox.Text = "";
                Mebox.Text = "Такой пользователь уже в клубе крутышек";

            }
            else 
            {
                var user = new User { Login = login, Password = pass, Email = email };
                context.Users.Add(user);
                context.SaveChanges();
                Mebox.Text = "";
                Mebox.Text = "Welvome to the club, buddy";
            }
         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow zareg = new MainWindow();
            zareg.Show();
        }
    }
}
