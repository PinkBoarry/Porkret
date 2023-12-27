using DBConnection.Models;
using iText.Forms;
using iText.Kernel.Pdf;
using System.IO;
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

        private void toClassSelectPage_Click(object sender, RoutedEventArgs e)
        {
            string sourcePdfPath = "C:\\Users\\Hru\\source\\repos\\CourseProject\\CourseProject\\Resources\\OriginList\\CharacterList_origin.pdf";
            string outputPdfPath = "C:\\Users\\Hru\\source\\repos\\CourseProject\\CourseProject\\Resources\\OriginList\\CharacterList_edited.pdf";
            using (PdfReader pdfReader = new PdfReader(sourcePdfPath))
            {
                using (PdfWriter pdfWriter = new PdfWriter(outputPdfPath))
                {
                    PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter);
                    PdfAcroForm acroForm = PdfAcroForm.GetAcroForm(pdfDocument, true);
                    acroForm.GetField("Race").SetValue(_raceSelectData.SelectedRace.Name);
                    pdfDocument.Close();
                }
            }
        }
    }
}
