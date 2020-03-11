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
        public void Track_ExistsAlreadyExact_Exception()
        {
            //Arrange
            Track.trackList = new List<Track>();
            Track.trackList.Add (new Track(1, 2, 58));
            var exceptionThrown = false;
            //Act
            try
            {
                Track.trackList.Add(new Track(1, 2, 58));
            }
            catch (Exception)
            {
                exceptionThrown = true;
            }

            //Assert
            Assert.IsTrue(exceptionThrown);
        }

    }

}
