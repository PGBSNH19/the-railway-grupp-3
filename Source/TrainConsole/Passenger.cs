namespace TrainConsole
{
    public class Passenger
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private Trip _curentTrip;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Firstname
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }



        public Trip CurentTrip
        {
            get { return _curentTrip; }
            set { _curentTrip = value; }
        }


    }
}