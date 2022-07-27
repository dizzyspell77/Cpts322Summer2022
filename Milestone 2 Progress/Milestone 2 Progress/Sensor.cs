using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_2_Progress
{
    class Sensor
    {
        public Point location {get; set;}
        public Sensor()
        {
            location = new Point();
        }
        public void setCoord(double x, double y)
        {
            location.x = x;
            location.y = y;
        }

        int Id { get; set; }

    }
}
