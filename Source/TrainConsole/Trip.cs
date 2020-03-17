using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Trip
    {
        public List<TimeTable> TrainStops;


        public Trip()
        {
            TrainStops = new List<TimeTable>();
        }
	}
}
