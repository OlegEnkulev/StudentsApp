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
    public partial class CreateUserPage : Page
    {
        public CreateUserPage()
        {
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameBox.Text.Length >= 2 && LastNameBox.Text.Length >= 3 && CourseBox.Text.Length >= 1) //Проверяем введены ли данные
            {
                int courseInt; //Объявляем переменную, которая содержит курс в виде числа

                try //Пробуем перевести введенные данные в число
                {
                    courseInt = int.Parse(CourseBox.Text);
                }
                catch //Если не получилось
                {
                    MessageBox.Show("Не удается преобразовать курс в число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if(courseInt != 0) //Проверка на введенное число курса
                {
                    Students student = new Students { FirstName = FirstNameBox.Text, LastName = LastNameBox.Text, Сourse = courseInt }; //создаем нового пользователя
                    Core.DB.Students.Add(student); //добавляем пользователя в БД
                    Core.DB.SaveChanges(); //Сохраняем изменения
                }

                Core.mainWindow.MainFrame.Navigate(new UsersPage()); //Открываем страницу студентов
            }
            else
                MessageBox.Show("Проверьте введены ли данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Core.mainWindow.MainFrame.Navigate(new UsersPage()); //Открываем страницу студентов
        }
    }
}
