using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RobotSim
{
    public class Sensor
    {
        public List<Point> pointsAroundCenter;
        public List<Point> pointsOnLine;
        //private int radius;
        public Sensor()
        {
            pointsAroundCenter = new List<Point>();
            pointsOnLine = new List<Point>();
        }

        public void calcPoints(Point center, int range)
        {
            pointsAroundCenter.Clear();
            int radius = range;

            int x = radius;
            int y = 0;
            int radiusError = 1 - x;
            while (x >= y)
            {
                pointsAroundCenter.Add(new Point(x + center.X, y + center.Y));
                pointsAroundCenter.Add(new Point(y + center.X, x + center.Y));
                pointsAroundCenter.Add(new Point(-x + center.X, y + center.Y));
                pointsAroundCenter.Add(new Point(-y + center.X, x + center.Y));
                pointsAroundCenter.Add(new Point(-x + center.X, -y + center.Y));
                pointsAroundCenter.Add(new Point(-y + center.X, -x + center.Y));
                pointsAroundCenter.Add(new Point(x + center.X, -y + center.Y));
                pointsAroundCenter.Add(new Point(y + center.X, -x + center.Y));

                y++;
                if (radiusError < 0)
                {
                    radiusError += 2 * y + 1;
                }
                else
                {
                    x--;
                    radiusError += 2 * (y - x + 1);
                }
            }

        }

        public void ClearLineList()
        {
            this.pointsOnLine.Clear();
        }

        public void CalcLine(Point startPoint, Point endPoint)
        {
            int dx = (int)(endPoint.X - startPoint.X);
            int dy = (int)(endPoint.Y - startPoint.Y);
            int delta = 2 * dy - dx;
            int y = (int)startPoint.Y;
            
            pointsOnLine.Add(startPoint);
            for (int x = (int)(startPoint.X + 1); x < (int)(endPoint.X); x++)
            {
                if (delta > 0)
                {
                    y += 1;
                    pointsOnLine.Add(new Point(x, y));
                    delta = delta + (2 * dy + 2 * dx);
                }
                else
                {
                    pointsOnLine.Add(new Point(x, y));
                    delta = delta + (2 * dy);
                }

            }



        }



    }
}
