using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace TrainConsole
{
    public class Data
    {
        public List<Track> Tracks = new List<Track>();
        public List<TrackSwitch> TrackSwitches = new List<TrackSwitch>();
        public List<Station> Stations = new List<Station>();
        public List<Train> Trains = new List<Train>();
        public List<Gate> Gates = new List<Gate>();
        public List<Trip> Trips = new List<Trip>();
        public List<Passenger> Passengers = new List<Passenger>();



        public void LoadAllFiles()
        {
           string path = @"C:\Dev\the-railway-grupp-3\Data\";
            LoadFile(path, "trains.txt");
            LoadFile(path, "passenger.txt");
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
                                var stations = new Station(int.Parse(values[0]), values[1], bool.Parse(values[3]));
                                Stations.Add(stations);
                                break;
                            case "timetable.txt":
                                var train = new Train(int.Parse(values[0]), values[1], int.Parse(values[2]), bool.Parse(values[3]));
                                Trains.Add(train);
                                break;
                            case "traintrack.txt":
                                var train = new Train(int.Parse(values[0]), values[1], int.Parse(values[2]), bool.Parse(values[3]));
                                Trains.Add(train);
                                break;

                            default:
                                break;
                        }
                    }
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
