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

namespace DzonyDetector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush strokeBrush = new(Colors.Red);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            foreach (var prevRect in Faces)
                canvas.Children.Remove(prevRect);
            Faces.Clear();

            string[] filesPaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            // TODO: odlisit obraz, vice obrazu, slozku a vice slozek
            im.Source = new BitmapImage(new Uri(filesPaths[0]));
            
            System.Drawing.Rectangle[] faces = FaceDetector.FaceDetector.Detect(filesPaths[0]);
            foreach(var face in faces)
            {
                Rectangle faceRect = new()
                {
                    Width = face.Width,
                    Height = face.Height,
                    StrokeThickness = 5,
                    Stroke = strokeBrush
                };
                Canvas.SetLeft(faceRect, face.X);
                Canvas.SetTop(faceRect, face.Y);
                canvas.Children.Add(faceRect);
                Faces.Add(faceRect);
            }
        }

        public List<Rectangle> Faces { get; } = new();
    }
}
