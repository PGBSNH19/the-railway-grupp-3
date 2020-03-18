using System;
using System.Linq;
using System.Threading;

namespace TrainConsole
{
    class Program
    {
        public static DateTime startTime = DateTime.Now;
        public static DateTime globaltime = DateTime.Parse("10:18");
        public static int timeMultiplier = 120;
        static Data data = new Data();

        private static void timetick(object state)
        {
            TimeSpan elapsedTime = (DateTime.Now - startTime)*timeMultiplier;
            startTime = DateTime.Now;
            globaltime += elapsedTime;

            Console.WriteLine(globaltime);
        }

        static void Main()
        {
            Timer t = new Timer(timetick, globaltime, 0, 1000);

            data.LoadAllFiles();


            while (true)
            {
                Thread.Sleep(500);
                CheckTimeTable();
            }
        }

        static void CheckTimeTable()
        {
            for (int i = 0; i < data.TimeTables.Count(); i++)
            {
                if (data.TimeTables[i].HasDeparted == false &&
                    globaltime > data.TimeTables[i].departureTime &&
                    data.TimeTables[i].departureTime != DateTime.Parse("00:00"))
                {
                    TellTrainToStart(i);
                }
            }
        }

        static void TellTrainToStart(int i)
        {
            var departureStation = data.Stations.Where(x => x.ID == data.TimeTables[i].stationId).FirstOrDefault();
            var arrivalStation = data.Stations.Where(x => x.ID == data.TimeTables[i + 1].stationId).FirstOrDefault();
            var track = Track.GetTrackByStationID(departureStation.ID, arrivalStation.ID);

            var currentTrain = data.Trains.Where(x => x.ID == data.TimeTables[i].traindId).FirstOrDefault();

            if (track.IsClear)
            {
                data.TimeTables[i].HasDeparted = true;
                TimeSpan journeyTime = (data.TimeTables[i + 1].arrivalTime - globaltime);

                currentTrain.StartTrain(currentTrain, departureStation, arrivalStation, journeyTime, track);
            }
            else
            {
                Console.WriteLine($"{currentTrain.Name} is waiting for the track infront to clear.");
            }
        }
    }
}
