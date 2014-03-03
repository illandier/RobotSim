using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RobotSim
{
    class Map
    {
        public int mapWidth { get; set; }
        public int mapHeight { get; set; }
        private int[,] mapFields;

        public Map(int width, int height)
        {
            this.mapWidth = width;
            this.mapHeight = height;
            mapFields = new int[height, width];
            for (int i = 0; i < this.mapHeight; i++)
            {
                for (int j = 0; j < this.mapWidth; j++)
                {
                    mapFields[i, j] = 0;
                    if (i == 5 && j == 5)
                    {
                        mapFields[i, j] = 2;
                    }
                }
            }
        }

        public void SetMapField(int x, int y, int value)
        {
            mapFields[y, x] = value;
        }

        public int[,] GetMapFields()
        {
            return this.mapFields;
        }

        public int GetMapField(int x, int y)
        {
            return this.mapFields[y, x];
        }
        public void SaveToFile()
        {
            StreamWriter sw = new StreamWriter("test.csv");
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (j > 0) sw.Write(",");
                    sw.Write(mapFields[i, j]);
                }
                sw.Write('\n');
            }
            sw.Close();
        }

        public void LoadMap()
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
                    this.SetMapField(x, y, int.Parse(temp[x]));
                    x++;
                }

                y++;

            }
            
        }


    }
}
