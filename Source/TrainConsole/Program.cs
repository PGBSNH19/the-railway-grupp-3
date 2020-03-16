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
                CurentTrain = data.Trains[0]
            };

            trip.Stations.Add(data.Stations.Where(x => x.Name == "Stonecro").FirstOrDefault());
            trip.Stations.Add(data.Stations.Where(x => x.ID == 2).FirstOrDefault());

            data.Trains[0].CurrentTrip = trip;

            data.Trains[0].StartTrain();

        }
    }
}
