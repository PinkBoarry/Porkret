using CourseProject.Pages;
using MainWork.Navigation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            navigationFrame.Navigate(new AuthorisationPage());

            NavigationManager.MainFrame = navigationFrame;

        }
    }
}
