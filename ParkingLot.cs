using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_2_Progress
{
    class ParkingLot
    { 

        public Slots data { get; set; }

        public int Total { get; set; }

        public ParkingLot()
        {
            //declare how many elements Slots[] will get
            data = new Slots;
        }
    }

}
