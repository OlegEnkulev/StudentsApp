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
    public partial class UsersPage : Page
    {

        public UsersPage()
        {
            InitializeComponent();

            DataGrid.ItemsSource = Core.DB.Students.ToArray(); //Покажем объекты из БД
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            Core.mainWindow.MainFrame.Navigate(new CreateUserPage()); //Открываем страницу создания студента
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            Core.DB.Entry(DataGrid.SelectedItem).State = System.Data.Entity.EntityState.Modified; //Присваиваем выбранному студенту статус "Изменён"
            Core.DB.SaveChanges(); //Сохраняем изменения
            MessageBox.Show("Изменения внесены");
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            Core.DB.Entry(DataGrid.SelectedItem).State = System.Data.Entity.EntityState.Deleted; //Присваиваем выбранному студенту статус "Удалён"
            Core.DB.SaveChanges(); //Сохраняем изменения
            MessageBox.Show("Изменения внесены");
            DataGrid.ItemsSource = Core.DB.Students.ToArray(); //Покажем объекты из БД
        }

        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox != null) //Проверка на введённый запрос
            {
                DataGrid.ItemsSource = Core.DB.Students.Where(x => x.FirstName.Contains(SearchBox.Text) || x.LastName.Contains(SearchBox.Text)).ToArray(); //Найдём элементы и покажем их в таблице
            }
            else
                DataGrid.ItemsSource = Core.DB.Students.ToArray(); //Покажем объекты из БД
        }

        private void ClearBTN_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = ""; //Отчистим окно поиска
            DataGrid.ItemsSource = Core.DB.Students.ToArray(); //Покажем объекты из БД
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            Core.mainWindow.MainFrame.Navigate(new LoginPage()); //Откроем окно авторизации
        }
    }
}
