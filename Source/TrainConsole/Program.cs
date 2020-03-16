using System;
using System.Linq;
using System.Threading;

namespace TrainConsole
{
    class Program
    {
        public static DateTime startTime = DateTime.Now;
        public static DateTime globaltime = DateTime.Parse("10:18");
        static Data data = new Data();

        private static void timetick(object state)
        {
            TimeSpan elapsedTime = (DateTime.Now - startTime)*60;
            startTime = DateTime.Now;
            globaltime = globaltime + elapsedTime;

            Console.WriteLine(globaltime);
        }

        static void Main()
        {
            Timer t = new Timer(timetick, globaltime, 0, 1000);
            data.LoadAllFiles();


            while (true)
            {
                Thread.Sleep(1000);
                CheckTimeTable();
            }
        }

        static void CheckTimeTable()
        {
            for (int i = 0; i < data.TimeTables.Count(); i++)
            {
                if (data.TimeTables[i].departureTime == RoundToNearest(globaltime, TimeSpan.FromMinutes(1)) && data.TimeTables[i].departureTime != DateTime.Parse("00:00"))
                {
                    var currentTrain = data.Trains.Where(x => x.ID == data.TimeTables[i].traindId).FirstOrDefault();
                    var arrivalTime = data.TimeTables[i + 1].arrivalTime;
                    var departureStation = data.Stations.Where(x => x.ID == data.TimeTables[i].stationId).FirstOrDefault();
                    var arrivalStation = data.Stations.Where(x => x.ID == data.TimeTables[i + 1].stationId).FirstOrDefault();

                    currentTrain.StartTrain(currentTrain, departureStation, arrivalStation, arrivalTime);

                    Thread.Sleep(200);
                }
            }
        }

        static DateTime RoundToNearest(DateTime dt, TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            bool roundUp = delta > d.Ticks / 2;
            var offset = roundUp ? d.Ticks : 0;

            return new DateTime(dt.Ticks + offset - delta, dt.Kind);
        }
    }
}
