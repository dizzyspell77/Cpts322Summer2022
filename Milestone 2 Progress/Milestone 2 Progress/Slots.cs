using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Milestone_2_Progress
{
    public class Slots
    {
      
        public Slot[] data { get; set; }
        public Point[] coordinates = new Point[4];
        public class isXY
        {
            public double x { get; set; }
            public double y { get; set; }
        }
    }

    public class Slot
    {
        private int spot;
        public int Total { get; set; }
        public Rectangle[] rect;
        int letter;
        Graphics G;

        
        public void DrawRect(Graphics G)
        {
            int x = 0;
            int y = 0;

            //if()
        }

       // public makeRed()
        //{

        //}


        public bool isInside(Point P)
        {
            //var coordinate;
            //var P.x = 0;
            var y = 0;
            return true;
        }

    }

    public class isOccupied
    {
        //bool isVacant();
    }
}
