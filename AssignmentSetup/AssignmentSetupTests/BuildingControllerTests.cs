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

        /// <summary>
        /// ////////////////HAVE TO WORK ON THIS//////////////////
        /// </summary>
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
        public void SetCurrentState_WhenParameterInput_ReturnFalse2()
        {
            // Arrange
            string input = "red";
            // Act
            BuildingController testBuilding = new BuildingController("test", "open");
            bool output = testBuilding.SetCurrentState(input);
            // Assert
            Assert.IsFalse(output);
        }
    }
}
