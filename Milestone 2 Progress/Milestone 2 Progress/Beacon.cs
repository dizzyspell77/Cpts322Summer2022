using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_2_Progress
{
    public class Beacon
    {
        public double D1 { get; set; }
        public double D2 { get; set; }
        public double D3 { get; set; }
        public double D4 { get; set; }
        public long Id { get; set; }
        public long Time { get; set; }
        private Point location;
        public void Update(Beacon data)
        {
            D1 = data.D1;
            D2 = data.D2;
            D3 = data.D3;
            D4 = data.D4;
            Time = data.Time;
        
        }

        public Point getXY(Sensors s)
        {
            Point P = new Point ();
            double x1 = s.data[0].location.x;
            double y1 = s.data[0].location.y;
            double x2 = s.data[1].location.x;
            double y2 = s.data[1].location.y;
            double x3 = s.data[2].location.x;
            double y3 = s.data[2].location.y;

            var A = 2 * x2 - 2 * x1;
            var B = 2 * y2 - 2 * y1;
            var C = Math.Pow(D1, 2) - Math.Pow(D2, 2) - Math.Pow(x1, 2) + Math.Pow(x2, 2) - Math.Pow(y1, 2) + Math.Pow(y2, 2);
            var D = 2 * x3 - 2 * y2;
            var E = 2 * y3 - 2 * y2;
            var F = Math.Pow(D2, 2) - Math.Pow(D3, 2) - Math.Pow(x2, 2) + Math.Pow(x3, 2) - Math.Pow(y2, 2) + Math.Pow(y3, 2);

            P.x = (C * E - F * B) / (E * A - B * D);
            P.y = (C * D - A * F) / (B * D - A * E);

            return P;
        }

    }
}
