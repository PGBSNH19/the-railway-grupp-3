using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Train
    {
		private int _id;
		private string _name;
		private int _maxSpeed;
		private bool _operated;
		private Trip _currentTrip;
		private List<Passenger> passengerList = new List<Passenger>();

		public Train(int id, string name, int maxSpeed, bool operated)
		{
			_id = id;
			_name = name;
			_maxSpeed = maxSpeed;
			_operated = operated;
		}

		Trip CurrentTrip
		{
			get { return _currentTrip; }
			set { _currentTrip = value; }
		}

		public bool Operated
		{
			get { return _operated; }
			set { _operated = value; }
		}


		public int MaxSpeed
		{
			get { return _maxSpeed; }
			set { _maxSpeed = value; }
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

		public void StartTrain(int trainid, int destinationid)
		{

		}

		public void StopTrain(int trainid)
		{

		}

	}
}
