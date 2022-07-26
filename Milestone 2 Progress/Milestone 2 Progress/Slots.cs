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

        public Slots()
        {
            var child = client.Child("Beacons/data");
            var observable = child.AsObservable<Beacon>();
            var r1 = 0;
            var r2 = 0;
            var r3 = 0;
            var x1 = 0;
            var y1 = 5;
            var x2 = 9;
            var y2 = 1.5;
            var x3 = 0;
            var y3 = 7;
            var A = 2 * x2 - 2 * x1;
            var B = 2 * y2 - 2 * y1;
            var C = Math.Pow(r1, 2) - Math.Pow(r2, 2) - Math.Pow(x1, 2) + Math.Pow(x2, 2) - Math.Pow(y1, 2) + Math.Pow(y2, 2);
            var D = 2 * x3 - 2 * y2;
            var E = 2 * y3 - 2 * y2;
            var F = Math.Pow(r2, 2) - Math.Pow(r3, 2) - Math.Pow(x2, 2) + Math.Pow(x3, 2) - Math.Pow(y2, 2) + Math.Pow(y3, 2);
            var x = (C * E - F * B) / (E * A - B * D);
            var y = (C * D - A * F) / (B * D - A * E);
            var xResult = x;
            var yResult = y;

            Graphics G;
            Rectangle[] rect = new Rectangle[6];
            //declare how many elements Slots[] will get
            data = new Slot[12];
            rect = Rectangle;

            //loop
            for (int i = 0; i < 12; i++)
            {
                rect[i] = new Rectangle(100 * i, 100, 100, 200);
                G.FillRectangle(myBrush, rect[i]);
                G.DrawRectangle(blackPen, rect[i]);
            }

            //data[i] = new Slot(i);

        }
    }

    public class Slot
    {
        public int Total { get; set; }
        public Rectangle rect { get; set; }
        public Slot(int index)
        {
            rect = new Rectangle(100 * index, 100, 100, 200);

        }

    }

    public class Point
    {
        int P = 0;
    }

    public class isOccupied
    {
        void bool isVacant();
    }

    bool isInside(Point P)
    {
        var coordinate[];
        coordinate[0].x <= P.x;
        coordinate[1].x > P.x;
        coordinate[0].y < P.y;
    }

    public class isNumber
    {

    }
}
