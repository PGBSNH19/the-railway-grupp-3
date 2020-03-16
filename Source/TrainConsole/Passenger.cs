namespace TrainConsole
{
    public class Passenger
    {
        private int _id;
        private string _name;
        private Trip _curentTrip;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Passenger(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public Trip CurentTrip
        {
            get { return _curentTrip; }
            set { _curentTrip = value; }
        }


    }
}