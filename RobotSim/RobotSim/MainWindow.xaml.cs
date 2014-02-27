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
        private string tmp;
        private void printMap1(int[,] map)
        {

            for (int i = 0; i < SetHeight; i++)
            {
                for (int j = 0; j < SetWidth; j++)
                {
                    tmp += map[i, j] + "\t";
                }
                tmp += '\n';
            }
            tmp += '\n';
            testBox.Text = tmp;
        }
        private void printMap2(int[,] map)
        {

            for (int i = 0; i < SetWidth; i++)
            {
                for (int j = 0; j < SetHeight; j++)
                {
                    tmp += map[i, j] + "\t";
                }
                tmp += '\n';
            }
            tmp += '\n';
            
        }

        private void TestMethod()
        {
            int[,] image = new int[SetHeight, SetWidth];
            Random rnd = new Random();
            int current = 0;
            for (int i = 0; i < SetHeight; i++)
            {
                for (int j = 0; j < SetWidth; j++)
                {

                    int x = rnd.Next(5);
                    image[i, j] = current;
                    current++;
                }
            }
            printMap1(image);
            int[,] newImage = new int[SetWidth, SetHeight];
            for (int i = SetHeight - 1; i >= 0; --i)
            {
                for (int j = 0; j < SetWidth; ++j)
                {
                    newImage[j, (SetHeight - 1) - i] = image[i, j];
                }
            }

            printMap2(newImage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            tmp = "";
            TestMethod();
            testBox.Text = tmp;
        }
    }
}
