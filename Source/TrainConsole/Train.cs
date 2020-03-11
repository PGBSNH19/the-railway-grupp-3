using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    class Train
    {
		private int _id;
		private string _name;
		private int _maxSpeed;
		private bool _operated;
		private int _capacity;
		private Trip _currentTrip;


		public Trip CurrentTrip
		{
			get { return _currentTrip; }
			set { _currentTrip = value; }
		}


		public int Capacity
		{
			get { return _capacity; }
			set { _capacity = value; }
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

	}
}
