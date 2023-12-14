using DBConnection.Data;
using DBConnection.Models;
using MainWork.Navigation;
using Microsoft.EntityFrameworkCore;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CourseProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationPage.xaml
    /// </summary>
    public partial class AuthorisationPage : Page
    {
        private AuthorisationPageModel _authorisationData;
        public AuthorisationPage()
        {
            InitializeComponent();
            _authorisationData = new AuthorisationPageModel();
            this.DataContext = _authorisationData;
        }

        private void toRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new RegistrationPage());
        }

        private void enterWithoutAuthorisationButton_Click(object sender, RoutedEventArgs e)
        {
            CreatorDbContext.currentUser = null;
            NavigationManager.MainFrame.Navigate(new SelectCharacterPage());
        }

        private void AuthorisationButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new CreatorDbContext())
            {
                string login = _authorisationData.AuthorizationLogin;
                string password = _authorisationData.AuthorizationPassword;

                //var user = context.Lab20Users.FirstOrDefault(user => user.UserLogin == login);
                var user = context.Users.AsNoTracking().FirstOrDefault(user => user.Login == login);
                PasswordHasher hasher = new PasswordHasher();
                if (user != null && hasher.VerifyPassword(password,user.Password))//user.Password == password)
                {
                    CreatorDbContext.currentUser = user.Login;
                    NavigationManager.MainFrame.Navigate(new SelectCharacterPage());
                }
                else
                {
                    MessageBox.Show("Вы не авторизованы! Попробуйте снова.", "Ошибка входа", MessageBoxButton.OK);
                }
            }
        }
    }
}
