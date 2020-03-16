using System;
using System.Linq;
using System.Threading;

namespace TrainConsole
{
    class Program
    {
        public static DateTime globaltime = DateTime.Parse("10:00");
        public static Timer t;
        private static void timetick(object state)
        {
            Console.WriteLine("test");
        }

        static void Main(string[] args)
        {
            t=new Timer(timetick, globaltime, 0, 1000);

            Data data = new Data();
            data.LoadAllFiles();
            var trip = new Trip
            {
                CurentTrain = data.Trains[0]
            };

            trip.Stations.Add(data.Stations.Where(x => x.Name == "Stonecro").FirstOrDefault());
            trip.Stations.Add(data.Stations.Where(x => x.ID == 2).FirstOrDefault());

            data.Trains[0].CurrentTrip = trip;

            data.Trains[0].StartTrain(data);

        }
    }
}
