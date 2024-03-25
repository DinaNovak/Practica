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

namespace praktika
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Login = LoginBox.Text;
            var password = TextBox1.Text;
            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => x.Login == Login && x.Password == password);
            if (user is null)
            {
                // MessageBox.Show("Неправильный логин или пароль!"); 
                Mebox.Text= "";
                Mebox.Text = "Неправильный логин или пароль!";
                return;
            }
            Mebox.Text = "";
            Mebox.Text = "Вы успешно вошли в аккаунт!";
            Window1 privki = new Window1();
            this.Hide();
            privki.Show();
            privki.priv.Text = "Здравствуй, " + LoginBox.Text;
            //MessageBox.Show("Вы успешно вошли в аккаунт!");
        }

        private void Zareg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registr reg = new Registr();
            reg.Show();
        }
        bool p = true;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (p)
            {
                PasswordBox.Visibility = Visibility.Collapsed;
                Glazik.Source = new BitmapImage(new Uri("Resours/2.png", UriKind.Relative));
                TextBox1.Text = PasswordBox.Password;
                TextBox1 .Visibility = Visibility.Visible;
                p = false;
            }
            else
            {
                PasswordBox.Visibility = Visibility.Visible;
                Glazik.Source = new BitmapImage(new Uri("Resours/1.png", UriKind.Relative));
                PasswordBox.Password = TextBox1.Text;
                TextBox1.Visibility = Visibility.Collapsed;
                p = true;

            }

        }

    }

}

