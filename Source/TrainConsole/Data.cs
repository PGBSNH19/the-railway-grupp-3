using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace TrainConsole
{
    public class Data
    {
        public List<Trip> Trips = new List<Trip>();
        public List<Track> Tracks = new List<Track>();
        public List<TrackSwitch> TrackSwitches = new List<TrackSwitch>();
        public List<Station> Stations = new List<Station>();
        public List<Train> Trains = new List<Train>();
        public List<Gate> Gates = new List<Gate>();
        public List<Passenger> Passengers = new List<Passenger>();
        public List<TimeTable> TimeTables = new List<TimeTable>();
        



        public void LoadAllFiles()
        {
            string path = @"..\..\..\..\..\Data\";

            LoadFile(path, "trains.txt");
            LoadFile(path, "passengers.txt");
            LoadFile(path, "stations.txt");
            LoadFile(path, "timetable.txt");
            LoadFile(path, "traintrack.txt");
        }

        public void LoadFile(string path, string fileName)
        {
            string separator = GetSplitCharacter(path, fileName);

            if (separator == "Empty")
            {
                throw new Exception("File is empty or unable to find the separator");
            }

            using (var reader = new StreamReader(path + fileName))
            {
                int count = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(separator);

                    if (count == 0)
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        switch (fileName)
                        {
                            case "trains.txt":
                                var train = new Train(int.Parse(values[0]), values[1], int.Parse(values[2]), bool.Parse(values[3]));
                                Trains.Add(train);
                                break;
                            case "passengers.txt":
                                var passenger = new Passenger(int.Parse(values[0]), values[1]);
                                Passengers.Add(passenger);
                                break;
                            case "stations.txt":
                                var stations = new Station(int.Parse(values[0]), values[1], bool.Parse(values[2]));
                                Stations.Add(stations);
                                break;
                            case "timetable.txt":
                                TimeTable timeTableRow;
                                if (values[2] == "null" && values[3] == "null")
                                {
                                    timeTableRow = new TimeTable(int.Parse(values[0]), int.Parse(values[1]), DateTime.Parse("00:00"), DateTime.Parse("00:00"));
                                }
                                else if (values[2] == "null")
                                {
                                    timeTableRow = new TimeTable(int.Parse(values[0]), int.Parse(values[1]), DateTime.Parse("00:00"), DateTime.Parse(values[3]));
                                }
                                else if (values[3] == "null")
                                {
                                    timeTableRow = new TimeTable(int.Parse(values[0]), int.Parse(values[1]), DateTime.Parse(values[2]), DateTime.Parse("00:00"));
                                }
                                else
                                {
                                    timeTableRow = new TimeTable(int.Parse(values[0]), int.Parse(values[1]), DateTime.Parse(values[2]), DateTime.Parse(values[3]));
                                }

                                CreateTrip(timeTableRow);
                                break;
                            case "traintrack.txt":
                                var track = new Track(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                                Tracks.Add(track);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void CreateTrip(TimeTable timeTableRow) 
        {
            var distinctList = TimeTables.Select(x => x.traindId).Distinct();
            foreach (var distinct in distinctList)
            {
                var partTripInTrip = TimeTables.Where(x => x.traindId == distinct).ToList();
            }


            foreach (var tripPart in Trips)
            {
                foreach (var trip in tripPart.TrainStops)
                {
                    if (trip.traindId == timeTableRow.traindId)
                    {

                    }
                }            
            }



            int trainID = 0;
            foreach (var tripPart in TimeTables)
            {
                //om samma id lägg till trip.TrainStops.Add(tripPart)
                // om annat id new trip



                if (trainID != tripPart.traindId)
                {
                    var trip = new Trip();
                    trainID = tripPart.traindId;
                    trip.TrainStops.Add(tripPart);
                    
                }
                else if (trainID == tripPart.traindId)
                {
                    // en del av samma trip
                }



            }


        }


        public string GetSplitCharacter(string path, string fileName)
        {
            var possibleSeparators = new List<char>();
            var score = new List<int>();

            using (var sr = new StreamReader(path + fileName))
            {
                if (sr.EndOfStream) { return "Empty"; }

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    foreach (var character in line)
                    {
                        if (!Char.IsLetterOrDigit(character) && !Char.IsWhiteSpace(character))
                        {
                            var index = possibleSeparators.IndexOf(character);
                            if (index < 0)
                            {
                                possibleSeparators.Add(character);
                                score.Add(0);
                            }
                            else
                            {
                                score[index] += 1;
                            }
                        }
                    }
                }
            }

            var maxIndex = score.IndexOf(score.Max());
            return possibleSeparators[maxIndex].ToString();
        }

    }
}
