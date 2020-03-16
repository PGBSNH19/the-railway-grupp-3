using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TrainConsole.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckGate_IsGateOpen_False()
        {
            //Arrange
            var gate = new Gate();
            //Act
           var result=gate.IsGateOpen();
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToggleGate_IsGateOpen_True()
        {
            //Arrange
            var gate = new Gate();

            //Act
            gate.ToggleGate();
            var result = gate.IsGateOpen();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckSwitch_IsSwitchRight_False()
        {
            //Arrange
            var trackSwitch = new TrackSwitch();
            //Act
            var result = trackSwitch.IsSwitchRight();
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToggleSwitch_IsSwitchRight_True()
        {
            //Arrange
            var trackSwitch = new TrackSwitch();

            //Act
            trackSwitch.ToggleSwitch();
            var result = trackSwitch.IsSwitchRight();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTrackInList_ExistsInTrackListExactOrInverted_True()
        {
            //Arrange
            Track.ClearTrackList();
            var track1 = new Track(1, 2, 58);

            //Act
            var result = track1.IsTrackInList(1, 2);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetDistanceFromStations_ValidStationInList_Distance()
        {
            //Arrange
            Track.ClearTrackList();
            var TestGetTrackByStationID = new Track(1, 2, 58);

            //Act
            var result = TestGetTrackByStationID.GetDistanceFromStations(1, 2);

            //Assert
            Assert.AreEqual(result, 58);
        }

        [TestMethod]
        public void GetDistanceFromStations_UnvalidStations_True()
        {
            //Arrange
            bool exceptionThrown = false;
            Track.ClearTrackList();
            var TestGetTrackByStationID = new Track(1, 2, 58);

            //Act
            try
            {
                var result = TestGetTrackByStationID.GetDistanceFromStations(3, 5);
            }
            catch (Exception)
            {
                exceptionThrown = true;
            }

            //Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GetTrackByStationID_ValidStations_TrackObject()
        {
            //Arrange
            Track.ClearTrackList();
            var track1 = new Track(1, 2, 58);

            //Act
            var result = track1.GetTrackByStationID(1, 2);

            //Assert
            Assert.IsInstanceOfType(result, typeof(Track));

        }

        [TestMethod]
        public void GetTrackByStationID_InvalidStations_Null()
        {
            //Arrange
            Track.ClearTrackList();
            var track1 = new Track(1, 2, 58);

            //Act
            var result = track1.GetTrackByStationID(3, 4);

            //Assert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void LoadTrains_CorrectDataFromFile_True()
        {
            //Arrange
            var data = new Data();
            string path = @"C:\Dev\the-railway-grupp-3\Data\";

            string fileName = "trains.txt";

            //Act
            data.LoadFile(path,fileName);
            //Assert
            Assert.AreEqual(data.Trains[0].ID, 1);
            Assert.AreEqual(data.Trains[0].Name, "Flying Scotsman");
            Assert.AreEqual(data.Trains[0].MaxSpeed, 100);
            Assert.AreEqual(data.Trains[0].Operated, false);

        }

    }

}
