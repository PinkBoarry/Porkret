using DBConnection.Models;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CourseProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectRacePage.xaml
    /// </summary>
    public partial class SelectRacePage : Page
    {
        private SelectRacePageModel _raceSelectData = new();
        public SelectRacePage()
        {
            InitializeComponent();

            _raceSelectData.index = 1;
            this.DataContext = _raceSelectData;

        }

        private void Race_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _raceSelectData.SelectRace((sender as FrameworkElement).DataContext as Race);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
