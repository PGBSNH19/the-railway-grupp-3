using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class TimeTable
    {
        private int _traindId;
        private int _stationId;
        private string _departureTime;
        private string _arrivalTime;


        public TimeTable(int trainId,int stationID, string departerTime, string arrivalTime)
        {
            _traindId = trainId;
            _stationId = stationID;
            _departureTime = departerTime;
            _arrivalTime = arrivalTime;

        }
    }


}
