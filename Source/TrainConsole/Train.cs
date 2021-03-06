﻿using System;
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
		private int _currentStationID;

		public int CurrentStationID
		{
			get { return _currentStationID; }
			set { _currentStationID = value; }
		}

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

		public void StartTrain(Train train, Station departureStation, Station arrivalStation, TimeSpan journeyTime, Track track)
		{
			string startMessage = $"{train.Name} avgår nu från {departureStation.Name}({departureStation.ID})({arrivalStation.ID}).";
			string endMessage = $"{train.Name} ankom nu till {arrivalStation.Name}({arrivalStation.ID}).";

			object parameters = new object[4] { journeyTime.Minutes, startMessage, endMessage, track };


			Thread thread = new Thread(() => StartTrainThread(parameters));
			thread.Start();
		}

		private static void StartTrainThread(object parameters)
		{
			Array argArray = new object[4];
			argArray = (Array)parameters;
			var track = (Track)argArray.GetValue(3);

			Console.WriteLine(argArray.GetValue(1) + $" Klockan: {Program.globaltime}");

			int journeyTime = int.Parse(argArray.GetValue(0).ToString());
			DateTime startTime = DateTime.Now;
			TimeSpan elapsedTime = (DateTime.Now - startTime) * Program.timeMultiplier;

			track.IsClear = false;
			while (elapsedTime.Minutes <= journeyTime)
			{
				Thread.Sleep(333);
				elapsedTime = (DateTime.Now - startTime) * Program.timeMultiplier;
			}
			track.IsClear = true;

			Console.WriteLine(argArray.GetValue(2) + $" Klockan: {Program.globaltime}");
		}
	}
}
