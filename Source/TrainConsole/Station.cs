using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Station
    {
		private int _id = 0;
		private string _name;
		private bool _isEndStation;


		public Station(int id, string name, bool isendstation)
		{
			_id = id;
			_name = name;
			_isEndStation = isendstation;
		}

		public bool IsEndStation
		{
			get { return _isEndStation; }
			set { _isEndStation = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

	}
}
