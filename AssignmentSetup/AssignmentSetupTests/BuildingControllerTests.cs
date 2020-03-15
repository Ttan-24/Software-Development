using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentSetup;
using NSubstitute;

namespace AssignmentSetupTests
{
    [TestFixture]
    public class BuildingControllerTests
    {
        // L1 REQUIREMENTS
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
            BuildingController buildingController = new BuildingController("id");

            // Act
            bool output = buildingController.SetCurrentState(input);

            // Assert
            Assert.IsTrue(output);
        }

        // Checking if different word put in the set current state would return a false 
        [TestCase ("red")]
        [TestCase("Green")]
        [TestCase("123")]
        [TestCase("RED")]
        [TestCase("open*")]
        public void SetCurrentState_WhenParameterInput_ReturnFalse(string parameterInput)
        {
            // Arrange
            string input = parameterInput;
            BuildingController buildingController = new BuildingController("id");

            // Act
            bool output = buildingController.SetCurrentState(input);

            // Assert
            Assert.IsFalse(output);
        }

        // Checking if the upper case, lower case and mixture of both letters are converted in lower case letters
        [TestCase ("OPEN")]
        [TestCase("CLOSED")]
        [TestCase("OUT OF HOURS")]
        [TestCase("Open")]
        [TestCase("oPen")]
        [TestCase("FIRE alarm")]
        [TestCase("fire Drill")]
        public void SetCurrentState_WhenInput_ConvertsInLowerCase_ReturnTrue(string parameterInput)
        {
            // Arrange
            string input = parameterInput;
            BuildingController buildingController = new BuildingController("id");

            // Act
            bool output = buildingController.SetCurrentState(input);

            // Assert
            Assert.IsTrue(output);
        }

        // Checking if word returns false if appropriate spaces not given; examples like fire alarm and fire drill
        [TestCase ("firealarm")]
        [TestCase("firedrill")]
        [TestCase("outofhours")]
        public void SetCurrentState_WhenInputWithoutSpace_ReturnFalse(string parameterInput)
        {
            // Arrange
            string input = parameterInput;
            BuildingController buildingController = new BuildingController("id");

            // Act
            bool output = buildingController.SetCurrentState(input);

            // Assert
            Assert.IsFalse(output);
        }

        // Checking if the set and get building id are working
        [Test]
        public void SetBuildingID_WhenGetBuildingID_ReturnAreEqual()
        {
            // Arrange
            string input = "id";
            BuildingController buildingController = new BuildingController("idString");

            // Act
            buildingController.SetBuildingID(input);
            string output = buildingController.GetBuildingID();

            // Assert
            Assert.AreEqual(input, output);
        }

        // Checking if the constructor is taking the string id parameter for the buildingID
        [Test]
        public void BuildingControllerParamter_WhenGetBuildingID_ReturnAreEqual()
        {
            // Arrange
            string input = "id";
            BuildingController buildingController = new BuildingController(input);

            // Act
            string output = buildingController.GetBuildingID();

            // Assert
            Assert.AreEqual(input, output);
        }

        // Checking if upper case and a mixture of both letters are converted into lower case letter in set and get building id
        [TestCase ("ID")]
        [TestCase("Id")]
        public void SetBuildingID_WhenInputCase_ReturnAreEqual(string parameterInput)
        {
            // Arrange
            string input = parameterInput;
            BuildingController buildingController = new BuildingController("idString");

            // Act
            buildingController.SetBuildingID(input);
            string output = buildingController.GetBuildingID();

            // Assert
            Assert.AreEqual(input.ToLower(), output);
        }


        // checking if the set and get CurrentState are working
        [Test]
        public void SetCurrentState_WhenGetCurrentState_ReturnAreEqual()
        {
            // Arrange
            string input = "open";
            BuildingController buildingController = new BuildingController("id");

            // Act
            buildingController.SetCurrentState(input);
            string output = buildingController.GetCurrentState();

            // Assert
            Assert.AreEqual(input, output);
        }

        // Checking if upper case letters are converted in lower case in get buildingID
        [Test]
        public void GetBuildingID_WhenInputCase_ReturnAreEqual()
        {
            // Arrange 
            string input = "MYID";
            BuildingController buildingController = new BuildingController(input);

            // Act
            string output = buildingController.GetBuildingID();

            // Assert
            Assert.AreEqual("myid", output);
        }

        // LVL2 REQUIREMENTS
        // chekcing if the additional constructor returns true
        [Test]
        public void SetCurrentState_WhenInput_ReturnTrue()
        {
            // Arrange
            string input = "open";
            BuildingController buildingController = new BuildingController("id", "open");

            // Act
            bool output = buildingController.SetCurrentState(input);

            // Assert
            Assert.IsTrue(output);
        }


        [Test]
        public void Constructor_WhenParameterInput_ThrowException()
        {
            // Arrange
            string input = "red";
               
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new BuildingController("id", input));
        }

        [Test]
        public void SetCurrentState_WhenInput_ReturnPreviousState()
        {
            // Arrange
            string inputOpen = "open";
            string inputFireAlarm = "fire alarm";
            string inputClosed = "closed";
            BuildingController buildingController = new BuildingController("id", inputOpen);

            // Act
            buildingController.SetCurrentState(inputFireAlarm);
            buildingController.SetCurrentState(inputClosed);
            string output = buildingController.GetCurrentState();

            // Assert
            Assert.AreEqual(inputOpen, output);
        }

        // LVL3 REQUIREMENTS
        // to check if the GetStatusReport calls the GetStatus methods of all three manager classes 
        // and returns in single string
        [Test]
        public void GetStatusReport_WhenGetStatus_ReturnString()
        {
            // Arrange
            BuildingController buildingController = new BuildingController("test");
            LightManager lightmanager = new LightManager();
            DoorManager doormanager = new DoorManager();
            FireAlarmManager firealarmmanager = new FireAlarmManager();

            // Act
            string lightStatus = lightmanager.GetStatus();
            string doorStatus = doormanager.GetStatus();
            string fireAlarmStatus = firealarmmanager.GetStatus();
            string result = lightStatus + doorStatus + fireAlarmStatus;
            string output = buildingController.GetStatusReport();

            // Assert
            Assert.IsTrue(result == output);
        }

        [Test]
        public void SetCurrentState_WhenOpen_ReturnOpenAllDoors()
        {
            // Arrange
            string input = "open";
            BuildingController buildingController = new BuildingController("id", input);
            DoorManager doormanager = new DoorManager();

            // Act
            bool output = doormanager.OpenAllDoors();

            // Assert
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_TrySetOpen_WhenDoorsCantOpen_ReturnFalse()
        {
            // Arrange
            string input = "open";
            DoorManager doormanager = new DoorManager();
            doormanager.canOpen = false;
            BuildingController buildingController = new BuildingController("id", new LightManager(), new FireAlarmManager(), doormanager, new WebService(), new EmailService());

            // Act
            buildingController.SetCurrentState("closed");
            bool output = buildingController.SetCurrentState(input);

            // Assert
            Assert.IsFalse(output);
        }

        [Test]
        public void SetCurrentState_TrySetOpen_WhenDoorsCanOpen_ReturnFalse()
        {
            // Arrange
            string input = "open";
            DoorManager doormanager = new DoorManager();
            doormanager.canOpen = true;
            BuildingController buildingController = new BuildingController("id", new LightManager(), new FireAlarmManager(), doormanager, new WebService(), new EmailService());

            // Act
            buildingController.SetCurrentState("closed");
            bool output = buildingController.SetCurrentState(input);

            // Assert
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenRoomIsClosed_DoorsAreLocked()
        {
            // Arrange
            string input = "open";
            DoorManager doormanager = new DoorManager();
            doormanager.canOpen = true;
            BuildingController buildingController = new BuildingController("id", new LightManager(), new FireAlarmManager(), doormanager, new WebService(), new EmailService());

            // Act
            buildingController.SetCurrentState("closed");
            bool output = doormanager.allLocked;

            // Assert
            Assert.IsTrue(output);
        }

        // LVL4 REQUIREMENTS
        [Test]
        public void SetCurrentState_WhenRoomIsClosed_LightsAreOff()
        {
            // Arrange
            string input = "closed";
            LightManager lightmanager = new LightManager();
            BuildingController buildingController = new BuildingController("id", lightmanager, new FireAlarmManager(), new DoorManager(), new WebService(), new EmailService());

            // Act
            buildingController.SetCurrentState(input);
            bool output = lightmanager.allLights;

            // Assert
            Assert.IsFalse(output);
        }

        [Test]
        public void SetCurrentState_WhenFireAlarm_AlarmIsActive()
        {
            // Arrange
            string input = "fire alarm";
            FireAlarmManager firealarmManager = new FireAlarmManager();
            BuildingController buildingController = new BuildingController("id", new LightManager(), firealarmManager, new DoorManager(), new WebService(), new EmailService());

            // Act
            buildingController.SetCurrentState(input);
            bool output = firealarmManager.alarmIsOn;

            // Assert
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenFireAlarm_ReturnOpenAllDoors()
        {
            // Arrange
            string input = "fire alarm";
            DoorManager doormanager = new DoorManager();
            BuildingController buildingController = new BuildingController("id", new LightManager(), new FireAlarmManager(), doormanager, new WebService(), new EmailService());

            // Act
            buildingController.SetCurrentState(input);
            bool output = doormanager.OpenAllDoors();

            // Assert
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenFireAlarm_LightsAreOn()
        {
            // Arrange
            string input = "fire alarm";
            LightManager lightmanager = new LightManager();
            BuildingController buildingController = new BuildingController("id", lightmanager, new FireAlarmManager(), new DoorManager(), new WebService(), new EmailService());

            // Act
            buildingController.SetCurrentState(input);
            bool output = lightmanager.allLights;

            // Assert
            Assert.IsTrue(output);
        }

        [Test]
        public void SetCurrentState_WhenFireAlarm_WebServiceLog()
        {
            // Arrange
            string input = "fire alarm";
            WebService testWebService = new WebService();
            BuildingController buildingController = new BuildingController("id", new LightManager(), new FireAlarmManager(), new DoorManager(), testWebService, new EmailService());

            // Act
            buildingController.SetCurrentState(input);
            string output = testWebService.log;

            // Assert
            Assert.IsTrue(output == "fire alarm");
        }
    }
}
