using System;
using System.Linq;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            data.LoadAllFiles();
            var trip = new Trip
            {
                CurentTrain = data.Trains[0],
                

            };

            trip.Stations.Add(data.Stations[0]);
            trip.Stations.Add(data.Stations[1]);

            data.Trains[0].CurrentTrip = trip;

            data.Trains[0].StartTrain();

        }
    }
}
