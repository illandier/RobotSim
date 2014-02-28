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
            SetWidth = int.Parse(MapSetWidth.Text);
            SetHeight = int.Parse(MapSetHeight.Text);
            newMap = new Map(SetWidth, SetHeight);
            ResetPosition();
            DrawCanvasGrid2();
        }
        public int GridSize { get; set; }
        public int SetWidth { get; set; }
        public int SetHeight { get; set; }
        private Map newMap;
        private Point currentPosition;

        private void ResetPosition()
        {
            currentPosition.X = 0;
            currentPosition.Y = 0;
        }

        void DrawCanvasGrid2()
        {

            CanvasMainWindow.Width = SetWidth * GridSize;
            CanvasMainWindow.Height = SetHeight * GridSize;
            CanvasMainWindow.Children.Clear();
            double width = CanvasMainWindow.Width;
            double height = CanvasMainWindow.Height;

            /*for (int i = 0; i < SetHeight; i++)
            {
                for (int j = 0; j < SetWidth; j++)
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
            }*/


            for (int i = 0; i < SetHeight; i++)
            {
                for (int j = 0; j < SetWidth; j++)
                {
                    Rectangle rec = new Rectangle();
                    rec.Stroke = Brushes.DarkGray;

                    rec.StrokeThickness = 1;
                    rec.Width = GridSize;
                    rec.Height = GridSize;
                    Canvas.SetTop(rec, (double)(i * GridSize));
                    Canvas.SetLeft(rec, (double)(j * GridSize));
                    if (newMap.GetMapField(j, i) == 0)
                    {
                        rec.Fill = Brushes.AliceBlue;

                    }
                    if (newMap.GetMapField(j, i) == 1)
                    {
                        rec.Fill = Brushes.Green;

                    }
                    if (newMap.GetMapField(j, i) == 2)
                    {
                        rec.Fill = Brushes.Gray;
                    }
                    if (newMap.GetMapField(j, i) == 3)
                    {
                        rec.Fill = Brushes.Yellow;
                    }
                    if (currentPosition.Y == i && currentPosition.X == j)
                    {
                        rec.Fill = Brushes.Red;
                    }
                    CanvasMainWindow.Children.Add(rec);
                }
            }

        }


        /*void DrawCanvasGrid()
        {
            SetWidth = int.Parse(MapSetWidth.Text);
            SetHeight = int.Parse(MapSetHeight.Text);
            CanvasMainWindow.Width = SetWidth * GridSize;
            CanvasMainWindow.Height = SetHeight * GridSize;
            CanvasMainWindow.Children.Clear();
            double width = CanvasMainWindow.Width;
            double height = CanvasMainWindow.Height;

            for (int i = 0; i < SetHeight; i++)
            {
                for (int j = 0; j < SetWidth; j++)
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

        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetWidth = int.Parse(MapSetWidth.Text);
            SetHeight = int.Parse(MapSetHeight.Text);
            newMap = new Map(SetWidth, SetHeight);
            ResetPosition();
            DrawCanvasGrid2();
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

        private void Move_Right()
        {
            if (currentPosition.X < (SetWidth - 1) && (newMap.GetMapField((int)(currentPosition.X + 1), (int) currentPosition.Y) != 2))
            {
                currentPosition.X++;
            }
        }

        private void Move_Left()
        {
            if (currentPosition.X > 0 && (newMap.GetMapField((int)(currentPosition.X - 1), (int)currentPosition.Y) != 2))
            {
                currentPosition.X--;
            }
        }

        private void Move_Down()
        {
            if (currentPosition.Y < (SetHeight - 1) && (newMap.GetMapField((int)(currentPosition.X), (int)(currentPosition.Y+1)) != 2))
            {
                currentPosition.Y++;
            }
        }

        private void Move_Up()
        {
            if (currentPosition.Y > 0 && (newMap.GetMapField((int)(currentPosition.X), (int)(currentPosition.Y - 1)) != 2))
            {
                currentPosition.Y--;
            }
        }

        private int f = 0;
        private void CanvasMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            bool keyPressed = false;
            if (e.Key == Key.D)
            {
                Move_Right();
                keyPressed = true;
            }
            if (e.Key == Key.A)
            {
                Move_Left();
                keyPressed = true;
            }
            if (e.Key == Key.S)
            {
                Move_Down();
                keyPressed = true;
            }
            if (e.Key == Key.W)
            {
                Move_Up();
                keyPressed = true;
            }

            f++;
            String abc = "Test: " + f.ToString();
            testBox.Text = abc;
            if (keyPressed)
            {
                DrawCanvasGrid2();
            }
        }
    }
}
