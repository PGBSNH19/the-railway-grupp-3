using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class TimeTable
    {
        public int traindId { get; set; }
        public int stationId { get; set; }
        public string departureTime { get; set; }
        public string arrivalTime { get; set; }


        public TimeTable(int trainId,int stationID, string departerTime, string arrivalTimeinput)
        {
            traindId = trainId;
            stationId = stationID;
            departureTime = departerTime;
            arrivalTime = arrivalTimeinput;

        }
    }


}
