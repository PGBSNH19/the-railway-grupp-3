using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class TimeTable
    {
        public int traindId { get; set; }
        public int stationId { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }


        public TimeTable(int trainId,int stationID, DateTime departerTime, DateTime arrivalTimeinput)
        {
            traindId = trainId;
            stationId = stationID;
            departureTime = departerTime;
            arrivalTime = arrivalTimeinput;

        }
    }


}
