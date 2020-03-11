using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Track
    {
		private static List<Track> trackList= new List<Track>();
		private int _stationA;
		private int _stationB;
		private int _distanceAB;

		private int _id = 0;

		public Track(int stationAID, int stationBID, int distanceAB)
		{
			AddTrackToList(stationAID, stationBID, distanceAB);
		}

		public void AddTrackToList(int stationAID, int stationBID, int distanceAB)
		{
			if (!IsTrackInList(stationAID, stationBID, distanceAB))
			{
				_stationA = stationAID;
				_stationB = stationBID;
				_distanceAB = distanceAB;
				_id++;
				trackList.Add(this);
			}
			else
			{
				throw new Exception("Track is already added.");
			}
			
		}

		public bool IsTrackInList(int stationAID, int stationBID, int distanceAB)
		{
			foreach (var track in trackList)
			{
				if ((track._stationA == stationAID && track._stationB == stationBID)
					|| (track._stationB == stationAID && track._stationA == stationBID))
				{
					return true;
				}
			}
			return false;
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
