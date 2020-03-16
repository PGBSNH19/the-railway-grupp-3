using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Trip
    {
		private List<Station> _stations = new List<Station>();
		private Train _curentTrain;
		private List<Track> _curentTrip;


		public List<Track> CurentTrip
		{
			get { return  _curentTrip; }
			set {  _curentTrip = value; }
		}


		public Train CurentTrain
		{
			get { return _curentTrain; }
			set { _curentTrain = value; }
		}


		public List<Station> Stations
		{
			get { return _stations; }
			set { _stations = value; }
		}

	}
}
