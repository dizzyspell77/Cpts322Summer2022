using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_2_Progress
{
    class Slots
    {
      
        public Slot[] data { get; set; }

        public class isXY
        {
            public double x { get; set; }
            public double y { get; set; }
        }
    }

    public class Slot
    {
        public int Total { get; set; }
        public Rectangle rect { get; set; }
        public Slot(int index)
        {

        }

    }

    public class isOccupied
    {
        void bool isVacant();
    }

    bool isInside(Point P)
    {
        var coordinate[];
        var x = 0;
        var y = 0;
        coordinate[0].x <= P.x;
        coordinate[1].x > P.x;
        coordinate[0].y <= P.y;
        coordinate[1].y > P.y;
    }

    public class isNumber
    {

    }
}
