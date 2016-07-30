using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        protected List<Point> pointList;

        public void Draw()
        {
            foreach (Point point in pointList)
            {
                point.Draw();
            }
        }

        public bool HadCollision(Figure figure)
        {
            foreach (Point point in pointList)
            {
                if (figure.HadCollision(point))
                    return true;
            }
            return false;
        }

        private bool HadCollision(Point point)
        {
            foreach (Point p in pointList)
            {
                if (p.HadCollision(point))
                    return true;
            }
            return false;
        }
    }
}
