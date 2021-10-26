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

namespace StudentsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new LoginPage()); //Откроем страницу авторизации
            Core.mainWindow = this; //Сохраним окно в памяти как переменную чтобы обращаться к нему из страниц в дальнейшем
        }
    }
}
