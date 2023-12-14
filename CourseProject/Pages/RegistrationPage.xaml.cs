using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
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
using DBConnection;
using DBConnection.Data;
using DBConnection.Models;
using MainWork.Navigation;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private RegistrationPageData _registrationData;
        public RegistrationPage()
        {
            InitializeComponent();

            _registrationData = new RegistrationPageData();
            this.DataContext = _registrationData;
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            string registrationLogin = _registrationData.RegisrationLogin;
            string registrationPassword = _registrationData.RegisrationPass;
            string confirmRegistrationPassword = _registrationData.RegistrationPassConfirm;

            if (registrationPassword == confirmRegistrationPassword
                && registrationLogin != ""
                && registrationPassword != "")
            {
                using (var context = new CreatorDbContext())
                {
                    if (context.Users.Where(item => item.Login == registrationLogin).FirstOrDefault() == null)
                    {
                        PasswordHasher hasher = new PasswordHasher();
                        User registerUser = new User
                        {
                            Login = registrationLogin,
                            Password = hasher.HashPasswordWithSalt(registrationPassword, BCrypt.Net.BCrypt.GenerateSalt(12))
                        };

                        context.Users.Add(registerUser);
                        context.SaveChanges();
                        MessageBox.Show($"{registrationLogin}, Вы успешно зарегистрировались!", "Успех", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        NavigationManager.MainFrame.Navigate(new AuthorisationPage());
                    }
                    else
                    {
                        MessageBox.Show($"Логин {registrationLogin} уже занят!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                        _registrationData.RegisrationLogin = "";
                        _registrationData.RegisrationPass = "";
                        _registrationData.RegistrationPassConfirm = "";
                    }
                }
            }
            else if (registrationPassword != confirmRegistrationPassword)
            {
                MessageBox.Show("Пароли не совпадают повторите ввод!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Некорректные данные повторите ввод!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void toAuthorisationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new AuthorisationPage());
        }
    }
}
