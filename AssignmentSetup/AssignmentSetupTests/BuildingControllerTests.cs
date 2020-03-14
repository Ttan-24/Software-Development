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
       [Test]
       public void testReturn()
        {
            // Arrange
            string input = "open";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            bool output = testBuilding.SetCurrentState(input);
            // Assert
            Assert.IsTrue(output);
        }

        // Checking if different word put in the set current state would return a false 
        [Test]
        public void testReturn2()
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
        public void testReturn3()
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
        public void testReturn4()
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
        public void testReturn5()
        {
            // Arrange
            string input = "meow";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            testBuilding.SetBuildingID(input);
            string output = testBuilding.GetBuildingID();
            // Assert
            Assert.AreEqual(input, output);
        }

        // Checking if captial letters are converted into lower case letter in set and get building id
        [Test]
        public void testReturn6()
        {
            // Arrange
            string input = "MEOW";
            // Act
            BuildingController testBuilding = new BuildingController("test");
            testBuilding.SetBuildingID(input);
            string output = testBuilding.GetBuildingID();
            // Assert
            Assert.AreEqual("meow", output);
        }

        
        // checking if the set and get are working
        [Test]
        public void testReturn7()
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
        public void testReturn8()
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
        public void testReturn9()
        {
            // Arrange
            string input = "MYID";
            // Act
            BuildingController testBuilding = new BuildingController(input);
            string output = testBuilding.GetBuildingID();
            // Assert
            Assert.AreEqual("myid", output);
        }
    }
}
