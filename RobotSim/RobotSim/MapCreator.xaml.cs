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
                    CanvasCreatorWindow.Children.Add(rec);
                }
            }

        }

        public MapCreator()
        {
            InitializeComponent();
            DrawCanvasGrid();
        }
        public MapCreator(int SetHeight, int SetWidth, int GridSize):this()
        {
            //InitializeComponent();
            this.GridSize = GridSize;
            this.SetWidth = SetWidth;
            this.SetHeight = SetHeight;
            DrawCanvasGrid();
        }
    }
}
