using Microsoft.VisualStudio.TestPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalCar7.Domain7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar7.Domain7.Tests
{
    [TestClass()]
    public class CarTests
    {
        [TestMethod()]
        public void Test_CalculateRentalCost_BMW()
        {
            // Arrange
            IVehicle target = new Car(ModelType.BMW);
            int daysRented = 3;
            int actual;
            int expected = 600;

            // Act
            actual = target.CalculateRentalCost(daysRented);

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}