using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentSetup;

namespace AssignmentSetupTests
{
    [TestFixture]
    public class BuildingControllerTests
    {
        // Chekcing if the set current state string words are checked valid
        [TestCase("open")]
        [TestCase("closed")]
        [TestCase("out of hours")]
        [TestCase("fire drill")]
        [TestCase("fire alarm")]
        public void SetCurrentState_WhenParameterInput_ReturnTrue(string parameterInput)
        {
            // Arrange
            string input = parameterInput;
            // Act
            BuildingController testBuilding = new BuildingController("test");
            bool output = testBuilding.SetCurrentState(input);
            // Assert
            Assert.IsTrue(output);
        }

        // Checking if different word put in the set current state would return a false 
        [Test]
        public void SetCurrentState_WhenRed_ReturnFalse()
        {
            // Arrange
            string input = "red";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            bool output = testBuilding.SetCurrentState(input);
            // Assert
            Assert.IsFalse(output);
        }

        // Checking if the Capital letters are converted in lower case letters
        [Test]
        public void SetCurrentState_WhenInputCapital_ReturnTrue()
        {
            // Arrange
            string input = "OPEN";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            bool output = testBuilding.SetCurrentState(input);
            // Assert
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenInputWithoutSpace_ReturnFalse()
        {
            // Arrange
            string input = "firealarm";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            bool output = testBuilding.SetCurrentState(input);
            // Assert
            Assert.IsFalse(output);
        }

        // Checking if the set and get building id are working
        [Test]
        public void SetBuildingID_WhenGetBuildingID_ReturnAreEqual()
        {
            // Arrange
            string input = "id";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            testBuilding.SetBuildingID(input);
            string output = testBuilding.GetBuildingID();
            // Assert
            Assert.AreEqual(input, output);
        }

        // Checking if captial letters are converted into lower case letter in set and get building id
        [Test]
        public void SetBuildingID_WhenInputCapital_ReturnAreEqual()
        {
            // Arrange
            string input = "ID";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            testBuilding.SetBuildingID(input);
            string output = testBuilding.GetBuildingID();
            // Assert
            Assert.AreEqual("id", output);
        }


        // checking if the set and get are working
        [Test]
        public void SetCurrentState_WhenGetCurrentState_ReturnAreEqual()
        {
            // Arrange
            string input = "open";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            testBuilding.SetCurrentState(input);
            string output = testBuilding.GetCurrentState();
            // Assert
            Assert.AreEqual(input, output);
        }

        [Test]
        public void GetBuildingID_WhenInput_ReturnAreEqual()
        {
            // Arrange
            string input = "myid";
            // Act
            BuildingController testBuilding = new BuildingController(input);
            string output = testBuilding.GetBuildingID();
            // Assert
            Assert.AreEqual(input, output);
        }

        [Test]
        public void GetBuildingID_WhenInputCapital_ReturnAreEqual()
        {
            // Arrange 
            string input = "MYID";
            // Act
            BuildingController testBuilding = new BuildingController(input);
            string output = testBuilding.GetBuildingID();
            // Assert
            Assert.AreEqual("myid", output);
        }


        [Test]
        public void SetCurrentState_WhenParameterInput_ReturnTrue2()
        {
            // Arrange
            string input = "open";
            // Act
            BuildingController testBuilding = new BuildingController("test", "open");
            bool output = testBuilding.SetCurrentState(input);
            // Assert
            Assert.IsTrue(output);
        }


        [Test]
        public void Constructor_WhenParameterInput_ThrowException()
        {
            // Arrange
            string input = "red";
            // Act      
            // Assert
            Assert.Throws<ArgumentException>(() => new BuildingController("test", input));
        }

        [Test]
        public void SetCurrentState_WhenInput_ReturnPreviousState()
        {
            // Arrange
            string input1 = "open";
            string input2 = "fire alarm";
            string input3 = "closed";

            // Act
            BuildingController testBuilding = new BuildingController("test", input1);
            testBuilding.SetCurrentState(input2);
            testBuilding.SetCurrentState(input3);
            string output = testBuilding.GetCurrentState();

            // Assert
            Assert.AreEqual(input1, output);
        }

        [Test]
        public void GetStatusReport_WhenGetStatus_ReturnString()
        {
            // Arrange

            // Act
            BuildingController testBuilding = new BuildingController("test");
            LightManager test = new LightManager();
            DoorManager test2 = new DoorManager();
            FireAlarmManager test3 = new FireAlarmManager();
            string output = test.GetStatus();
            string output2 = test2.GetStatus();
            string output3 = test3.GetStatus();
            string result = output + output2 + output3;
            string output4 = testBuilding.GetStatusReport();
            // Assert
            Assert.IsTrue(result == output4);
        }

        [Test]
        public void SetCurrentState_WhenOpen_ReturnOpenAllDoors()
        {
            string input = "open";
            BuildingController testBuilding = new BuildingController("test", input);
            DoorManager test = new DoorManager();
            bool output = test.OpenAllDoors();
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_TrySetOpen_WhenDoorsCantOpen_ReturnFalse()
        {
            string input = "open";
            DoorManager testDoorManager = new DoorManager();
            testDoorManager.canOpen = false;
            BuildingController testBuilding = new BuildingController("test", new LightManager(), new FireAlarmManager(), testDoorManager, new WebService(), new EmailService());
            testBuilding.SetCurrentState("closed");
            bool output = testBuilding.SetCurrentState(input);
            Assert.IsFalse(output);
        }

        [Test]
        public void SetCurrentState_TrySetOpen_WhenDoorsCanOpen_ReturnFalse()
        {
            string input = "open";
            DoorManager testDoorManager = new DoorManager();
            testDoorManager.canOpen = true;
            BuildingController testBuilding = new BuildingController("test", new LightManager(), new FireAlarmManager(), testDoorManager, new WebService(), new EmailService());
            testBuilding.SetCurrentState("closed");
            bool output = testBuilding.SetCurrentState(input);
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenRoomIsClosed_DoorsAreLocked()
        {
            string input = "open";
            DoorManager testDoorManager = new DoorManager();
            testDoorManager.canOpen = true;
            BuildingController testBuilding = new BuildingController("test", new LightManager(), new FireAlarmManager(), testDoorManager, new WebService(), new EmailService());
            testBuilding.SetCurrentState("closed");
            bool output = testDoorManager.allLocked;
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenRoomIsClosed_LightsAreOff()
        {
            string input = "closed";
            LightManager testLightManager = new LightManager();
            BuildingController testBuilding = new BuildingController("test", testLightManager, new FireAlarmManager(), new DoorManager(), new WebService(), new EmailService());
            testBuilding.SetCurrentState(input);
            bool output = testLightManager.allLights;
            Assert.IsFalse(output);
        }

        [Test]
        public void SetCurrentState_WhenFireAlarm_AlarmIsActive()
        {
            string input = "fire alarm";
            FireAlarmManager testFireAlarmManager = new FireAlarmManager();
            BuildingController testBuilding = new BuildingController("test", new LightManager(), testFireAlarmManager, new DoorManager(), new WebService(), new EmailService());
            testBuilding.SetCurrentState(input);
            bool output = testFireAlarmManager.alarmIsOn;
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenFireAlarm_ReturnOpenAllDoors()
        {
            string input = "fire alarm";
            DoorManager testDoorManager = new DoorManager();
            BuildingController testBuilding = new BuildingController("test", new LightManager(), new FireAlarmManager(), testDoorManager, new WebService(), new EmailService());
            testBuilding.SetCurrentState(input);
            bool output = testDoorManager.OpenAllDoors();
            Assert.IsTrue(output);
        }
    }
}
