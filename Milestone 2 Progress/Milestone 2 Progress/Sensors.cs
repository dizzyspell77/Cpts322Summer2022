using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_2_Progress
{
    public class Sensors
    {
        public Sensor[] data { get; set; }

        public Sensors(int size)
        {
            data = new Sensor[size];
            data[0] = new Sensor();
            data[1] = new Sensor();
            data[2] = new Sensor();
            data[3] = new Sensor();
        }

    }
}
