using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

		public Trip CurrentTrip
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

		public void StartTrain(Data data)
		{
			Thread thread = new Thread(new ThreadStart(StartTrainThread));
			thread.Start();
		}

		private static void StartTrainThread()
		{
			string count = "0";
			while (count != "8")
			{
				Thread.Sleep(200);
				Console.WriteLine("Tuff Tuf maddafakka");
			}
			
		}

		public void StopTrain(int trainid)
		{

		}

		public void CheckWithController(bool istrackclered)
		{

		}

	}
}
