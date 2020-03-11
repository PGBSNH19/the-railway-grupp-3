using System;
using System.Collections.Generic;
using System.Text;

namespace TrainConsole
{
    public class Controller
    {
		private bool _isTrainClearedForDeparture;

		public bool IsTrainClearedForDeparture
		{
			get { return _isTrainClearedForDeparture; }
			set { _isTrainClearedForDeparture = value; }
		}

		public void OpenGate() 
		{
			
		}
		public void CloseGate() { }

		

	}
}
