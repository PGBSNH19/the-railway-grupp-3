using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TrainConsole
{
   public class Data
    {
		public List<Track> Tracks = new List<Track>();
		public List<TrackSwitch> TrackSwitches = new List<TrackSwitch>();
		public List<Station> Stations = new List<Station>();
		public List<Train> Trains = new List<Train>();
		public List<Gate> Gates = new List<Gate>();
		public List<Trip> Trips = new List<Trip>();
		public List<Passenger> Passengers = new List<Passenger>();



		public  void LoadAllFiles()
		{ 
			
		}

		public void LoadTrains()
		{
			using (var reader = new StreamReader(@"C:\Dev\the-railway-grupp-3\Data\trains.txt"))
			{
				int count = 0;
				while (!reader.EndOfStream)
				{
						var line = reader.ReadLine();
						var values = line.Split(',');
						Console.WriteLine(values[0] + values[1] + values[2] + values[3]);

					if (count == 0)
					{
						count++;
						continue;
					}
					else
					{
						var train = new Train(int.Parse(values[0]), values[1], int.Parse(values[2]), bool.Parse(values[3]));
						Trains.Add(train);
					}
				}
			}
		}

		public void AddTrainToList(Train train)
		{
			
		}



	}
}
