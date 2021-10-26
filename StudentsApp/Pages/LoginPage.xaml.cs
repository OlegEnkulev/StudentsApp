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
using StudentsApp.Pages;
using StudentsApp.Resources;

namespace StudentsApp.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length >= 4 && PasswordBox.Password.Length >= 4) //Проверка ввода данных
            {
                Users user = Core.DB.Users.Where(s => s.Login == LoginBox.Text).FirstOrDefault(); //Пытаемся найти пользователя

                if (user != null) //Проверка существования пользователя
                {
                    if(user.Password == PasswordBox.Password) //Проверка пароля
                    {
                        Core.mainWindow.MainFrame.Navigate(new UsersPage()); //Переключение страницы
                    }
                    else
                        MessageBox.Show("Пароль неверен", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Не удалось найти пользователя", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Данные некорректны!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}