using DBConnection.Data;
using DBConnection.Models;
using MainWork.Navigation;
using Pages;
using System;
using System.Windows.Controls;

namespace CourseProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectCharacterPage.xaml
    /// </summary>
    public partial class SelectCharacterPage : Page
    {
        private SelectCharacterPageModel _selectCharacterPageModel;
        public SelectCharacterPage()
        {
            InitializeComponent();
            _selectCharacterPageModel = new SelectCharacterPageModel();
            
            if (_selectCharacterPageModel.CurrentUser == null ) 
            {
                _selectCharacterPageModel.CurrentUser = "Гость";
            }
            else
            {
                toCreatedCharactersPageButton.Visibility = System.Windows.Visibility.Visible;
            }
            this.DataContext = _selectCharacterPageModel;
        }

        private void createCharacterButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new SelectRacePage());
        }

        private void exitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new AuthorisationPage());
        }
    }
}
