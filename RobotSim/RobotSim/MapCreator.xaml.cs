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
using System.Windows.Shapes;

namespace RobotSim
{
    /// <summary>
    /// Interaction logic for MapCreator.xaml
    /// </summary>
    public partial class MapCreator : Window
    {
        public int GridSize { get; set; }
        public int SetWidth { get; set; }
        public int SetHeight { get; set; }
        private Map newMap;

        void DrawCanvasGrid()
        {

            CanvasCreatorWindow.Width = SetWidth * GridSize;
            CanvasCreatorWindow.Height = SetHeight * GridSize;
            CanvasCreatorWindow.Children.Clear();
            double width = CanvasCreatorWindow.Width;
            double height = CanvasCreatorWindow.Height;

            for (int i = 0; i < SetWidth; i++)
            {
                for (int j = 0; j < SetHeight; j++)
                {
                    Rectangle rec = new Rectangle();
                    rec.Stroke = Brushes.DarkGray;
                    
                    rec.StrokeThickness = 1;
                    rec.Width = GridSize;
                    rec.Height = GridSize;
                    Canvas.SetTop(rec, (double)(j * GridSize));
                    Canvas.SetLeft(rec, (double)(i * GridSize));
                    if (newMap.GetMapField(i, j) == 0)
                    {
                        rec.Fill = Brushes.AliceBlue;

                    }
                    if (newMap.GetMapField(i,j) == 1)
                    {
                        rec.Fill = Brushes.Green;
                        
                    }
                    if (newMap.GetMapField(i, j) == 2)
                    {
                        rec.Fill = Brushes.Gray;
                    }
                    if (newMap.GetMapField(i, j) == 3)
                    {
                        rec.Fill = Brushes.Yellow;
                    }
                    CanvasCreatorWindow.Children.Add(rec);
                }
            }

        }

        public MapCreator()
        {
            InitializeComponent();
            DrawCanvasGrid();
            //newMap = new Map(SetHeight, SetWidth);
        }
        public MapCreator(int SetHeight, int SetWidth, int GridSize)
            : this()
        {
            //InitializeComponent();
            this.GridSize = GridSize;
            this.SetWidth = SetWidth;
            this.SetHeight = SetHeight;
            newMap = new Map(SetHeight, SetWidth);
            DrawCanvasGrid();
            
        }



        private void CanvasCreatorWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Point MousePosition = e.GetPosition(CanvasCreatorWindow);
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                int i = 0;
                int j = 0;
                i = (int)(MousePosition.X / GridSize);
                j = (int)(MousePosition.Y / GridSize);
                wynikX.Text = i.ToString();
                wynikY.Text = j.ToString();

                Rectangle rec = new Rectangle();

                rec.Stroke = Brushes.DarkGray;
                rec.StrokeThickness = 1;
                rec.Width = GridSize;
                rec.Height = GridSize;
                Canvas.SetTop(rec, (double)(j * GridSize));
                Canvas.SetLeft(rec, (double)(i * GridSize));

                if ((string)ModeComboBox.SelectedValue == "1")
                {
                    rec.Fill = Brushes.Green;
                    newMap.SetMapField(i, j, 1);
                }
                if ((string)ModeComboBox.SelectedValue == "2")
                {
                    rec.Fill = Brushes.Gray;
                    newMap.SetMapField(i, j, 2);
                }
                if ((string)ModeComboBox.SelectedValue == "3")
                {
                    rec.Fill = Brushes.Yellow;
                    newMap.SetMapField(i, j, 3);
                }
                CanvasCreatorWindow.Children.Add(rec);
            }

            if (e.RightButton == MouseButtonState.Pressed)
            {

                int i = 0;
                int j = 0;
                i = (int)(MousePosition.X / GridSize);
                j = (int)(MousePosition.Y / GridSize);
                wynikX.Text = i.ToString();
                wynikY.Text = j.ToString();

                Rectangle rec = new Rectangle();
                rec.Fill = Brushes.AliceBlue;
                rec.Stroke = Brushes.DarkGray;
                rec.StrokeThickness = 1;
                rec.Width = GridSize;
                rec.Height = GridSize;
                Canvas.SetTop(rec, (double)(j * GridSize));
                Canvas.SetLeft(rec, (double)(i * GridSize));
                newMap.SetMapField(i, j, 0);
                CanvasCreatorWindow.Children.Add(rec);

            }

        }

        private void LoadMap()
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newMap.SaveToFile();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string fileContent = System.IO.File.ReadAllText("test.csv");

            string[] fileContentSplit = fileContent.Split('\n');
            string[,] mapTemp;

            int y = 0;
            foreach (string c in fileContentSplit)
            {
                if (c == "") break;
                string[] temp = c.Split(',');
                int x = 0;
                
                foreach (string d in temp)
                {
                    newMap.SetMapField(y, x, int.Parse(temp[x]));
                    x++;
                }

                y++;

            }
            DrawCanvasGrid();
        }


    }
}
