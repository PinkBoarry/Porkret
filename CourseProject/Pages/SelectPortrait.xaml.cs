using iText.Forms;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectPortrait.xaml
    /// </summary>
    public partial class SelectPortrait : System.Windows.Controls.Page
    {
        public SelectPortrait()
        {
            InitializeComponent();
            string projectRoot = Environment.CurrentDirectory;
            string relativePath = @"Resources\Images\Portraits";
            string fullPath = System.IO.Path.Combine(projectRoot, relativePath);
            LoadImagesFromFolder(fullPath);

        }
        private void LoadImagesFromFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                List<BitmapImage> images = new List<BitmapImage>();
                string[] imagePaths = Directory.GetFiles(folderPath, "*.jpg");
                foreach (string path in imagePaths)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(path));
                    images.Add(bitmap);
                }
                imageItemsControl.ItemsSource = images;
            }
            else
            {
                MessageBox.Show("Указанная папка не найдена");
            }
        }

        private void Portrait_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image clickedImage = (Image)sender;
            selectedPortraitImage.Source = clickedImage.Source;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
