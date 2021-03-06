﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Track
    {
		public static List<Track> trackList= new List<Track>();
		private int _stationA;
		private int _stationB;
		private int _distanceAB;
		private bool _isTrackClear;

		public bool IsClear
		{
			get { return _isTrackClear; }
			set { _isTrackClear = value; }
		}


		private int _id = 0;

		public Track(int ID, int stationAID, int stationBID, int distanceAB)
		{
			AddTrackToList(ID, stationAID, stationBID, distanceAB);
		}

		public void AddTrackToList(int ID, int stationAID, int stationBID, int distanceAB)
		{
			if (!IsTrackInList(stationAID, stationBID))
			{
				_id = ID;
				_stationA = stationAID;
				_stationB = stationBID;
				_distanceAB = distanceAB;
				trackList.Add(this);
				_isTrackClear = true;
			}
			else
			{
				throw new Exception("Track is already added.");
			}
		}

		public static void ClearTrackList()
		{
			trackList.Clear();
		}

		public bool IsTrackInList(int stationAID, int stationBID)
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

		public int GetDistanceFromStations(int stationAID, int stationBID) 
		{
			if (IsTrackInList(stationAID, stationBID))
			{
				var current = GetTrackByStationID(stationAID, stationBID);
				return current.Distance;
			}
			throw new Exception("Station ID's are not valid.");
		}

		public static Track GetTrackByStationID(int stationAID, int stationBID)
		{
			foreach (var track in trackList)
			{
				if ((track._stationA == stationAID && track._stationB == stationBID)
					|| (track._stationB == stationAID && track._stationA == stationBID))
				{
					return track;
				}
			}
			return null;
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
