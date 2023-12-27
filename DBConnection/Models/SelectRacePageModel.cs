using CommunityToolkit.Mvvm.ComponentModel;
using DBConnection.Data;

namespace DBConnection.Models
{
    [ObservableObject]
    public partial class SelectRacePageModel
    {
        public List<Race> Races { get; set; }
        public int index { get; set; }

        public SelectRacePageModel()
        {
            Races = GetRacesFromDatabase();
        }
        [ObservableProperty]
        public Race _selectedRace;
        public string SelectedRaceName { get; set; }
        public string SelectedHistory { get; set; }
        public string SelectedPeculiarities { get; set; }
        public string IconPath { get; set; }
        private List<Race> GetRacesFromDatabase()
        {
            using (var context = new CreatorDbContext())
            {
                return new List<Race>(context.Races.ToList().Where(r => r.IconPath.Length > 0));
            }
        }
        public void SelectRace(Race race)
        {
            race.Peculiarities = race.Peculiarities.Replace(';', '\n');
            SelectedRace = race;
        }
        static HttpClient client = new HttpClient();

    }
}
