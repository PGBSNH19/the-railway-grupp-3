using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    class Track
    {
		private static List<Track> trackList;
		private int _stationA;
		private int _stationB;
		private int _distanceAB;
		private int _distanceBA;

		private int _id = 0;
		
		public Track(int stationAID, int stationBID, int distanceAB)
		{
			foreach (var track in trackList)
			{
				if (true)
				{
					

				}
			}

			_stationA = stationAID;
			_stationB = stationBID;
			_distance = distanceAB;

			_id++;
		}

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		public int StationA
		{
			get { return _stationA; }
			set { _stationA = value; }
		}

		public int StationB
		{
			get { return _stationB; }
			set { _stationB = value; }
		}

		public int Distance
		{
			get { return _distance; }
			set { _distance = value; }
		}
	}
}
