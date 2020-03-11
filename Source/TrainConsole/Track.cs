using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Track
    {
		public static List<Track> trackList;
		private int _stationA;
		private int _stationB;
		private int _distanceAB;

		private int _id = 0;
		
		public Track(int stationAID, int stationBID, int distanceAB)
		{
			foreach (var track in trackList)
			{
				if ((track._stationA == stationAID && track._stationB == stationBID) 
					|| (track._stationB == stationAID && track._stationA == stationBID))
				{
					throw new Exception("Track already exists.");
				}
			}

			_stationA = stationAID;
			_stationB = stationBID;
			_distanceAB = distanceAB;
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
			get { return _distanceAB; }
			set { _distanceAB = value; }
		}
	}
}
