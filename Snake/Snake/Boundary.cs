using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   
    class Boundary
    {
        List<Figure> boundaryList;

        public Boundary(int mapWidth, int mapHeight)
        {
            boundaryList = new List<Figure>();

            HorisontalLine upLine = new HorisontalLine(0, mapWidth - 2, 0, '-');
            HorisontalLine downLine = new HorisontalLine(0, mapWidth - 2, 24, '-');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '|');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '|');

            boundaryList.Add(upLine);
            boundaryList.Add(downLine);
            boundaryList.Add(leftLine);
            boundaryList.Add(rightLine);
        }

        
        public void Draw()
        {
            foreach (var boundary in boundaryList)
            {
                boundary.Draw();
            }
        }
        
        public bool HadCollision(Figure figure)
        {
            foreach (var boundary in boundaryList)
            {
                if (boundary.HadCollision(figure))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
