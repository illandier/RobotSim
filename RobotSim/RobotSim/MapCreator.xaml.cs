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
                    newMap.SetMapField(j, i, 1);
                }
                if ((string)ModeComboBox.SelectedValue == "2")
                {
                    rec.Fill = Brushes.Gray;
                    newMap.SetMapField(j, i, 2);
                }
                if ((string)ModeComboBox.SelectedValue == "3")
                {
                    rec.Fill = Brushes.Yellow;
                    newMap.SetMapField(j, i, 3);
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
                newMap.SetMapField(j, i, 0);
                CanvasCreatorWindow.Children.Add(rec);

            }

        }

        private void LoadMap()
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newMap.LoadMap();
            DrawCanvasGrid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            newMap.SaveToFile();
            
        }


    }
}
