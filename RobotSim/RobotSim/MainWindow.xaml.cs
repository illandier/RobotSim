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

namespace RobotSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GridSize = 15;
            DrawCanvasGrid();
        }
        public int GridSize { get; set; }
        public int SetWidth { get; set; }
        public int SetHeight { get; set; }

        void DrawCanvasGrid()
        {
            SetWidth = int.Parse(MapSetWidth.Text);
            SetHeight = int.Parse(MapSetHeight.Text);
            CanvasMainWindow.Width = SetWidth * GridSize;
            CanvasMainWindow.Height = SetHeight * GridSize;
            CanvasMainWindow.Children.Clear();
            double width = CanvasMainWindow.Width;
            double height = CanvasMainWindow.Height;

            for (int i = 0; i < SetWidth; i++)
            {
                for (int j = 0; j < SetHeight; j++)
                {
                    Rectangle rec = new Rectangle();
                    rec.Stroke = Brushes.DarkGray;
                    rec.Fill = Brushes.AliceBlue;
                    rec.StrokeThickness = 1;
                    rec.Width = GridSize;
                    rec.Height = GridSize;
                    Canvas.SetTop(rec, (double)(j * GridSize));
                    Canvas.SetLeft(rec, (double)(i * GridSize));
                    CanvasMainWindow.Children.Add(rec);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DrawCanvasGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var CreatorWindow = new MapCreator(SetHeight, SetWidth, GridSize);
            CreatorWindow.Show();
        }
    }
}
