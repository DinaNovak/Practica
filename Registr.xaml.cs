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
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login== login);
            if (EmailBox.Text.Contains("@gmail.com")||(EmailBox.Text.Contains("@mail.ru"))||(EmailBox.Text.Contains("@yandex.ru")) == false) ;
            {
                MessageBox.Show("Неверный адрес почты");
            }
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже в клубе крутышек");
                return;

            }
            var user = new User {  Login = login, Password = pass };
            context.Users.Add(user);    
            context.SaveChanges();
            MessageBox.Show("Welvome to the club, buddy");

         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow zareg = new MainWindow();
            zareg.Show();
        }
    }
}
