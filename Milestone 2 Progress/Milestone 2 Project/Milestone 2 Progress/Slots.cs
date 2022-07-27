using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        public Rectangle[] rect;
        public Slot(int i)
        {
            int x;
            int y;

            rect= new Rectangle(100 * i, 100, 100, 200);

        }

        public makeRed()
        {

        }


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

  

    public class isNumber
    {

    }
}
