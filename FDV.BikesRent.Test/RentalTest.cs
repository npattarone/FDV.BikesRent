using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FDV.BikesRent.Test
{
    [TestClass]
    public class RentalTest
    {
        [TestMethod]
        public void RentByHourForThreeHours()
        {
            var rental = new RentalContext();
            rental.SetRentalStrategy(new CommonRental());

            rental.AddRent(new Rental(3, 5, RentTypeEnum.ByHour));

            Assert.IsTrue(rental.CalculateTotal() == 3 * 5);
            Assert.IsTrue(rental.Rentals.Count == 1);
            Assert.IsTrue(rental.Rentals.First().RentType == RentTypeEnum.ByHour);
        }

        [TestMethod]
        public void RentByWeekForTwoWeeks()
        {
            var rental = new RentalContext();
            rental.SetRentalStrategy(new CommonRental());

            rental.AddRent(new Rental(2, 60, RentTypeEnum.ByWeek));

            Assert.IsTrue(rental.CalculateTotal() == 2 * 60);
            Assert.IsTrue(rental.Rentals.Count == 1);
            Assert.IsTrue(rental.Rentals.First().RentType == RentTypeEnum.ByWeek);
        }

        [TestMethod]
        public void RentByDayForFourDays()
        {
            var rental = new RentalContext();
            rental.SetRentalStrategy(new CommonRental());

            rental.AddRent(new Rental(4, 20, RentTypeEnum.ByDay));

            Assert.IsTrue(rental.CalculateTotal() == 4 * 20);
            Assert.IsTrue(rental.Rentals.Count == 1);
            Assert.IsTrue(rental.Rentals.First().RentType == RentTypeEnum.ByDay);
        }

        [TestMethod]
        public void FamilyRental()
        {
            var rental = new RentalContext();
            rental.SetRentalStrategy(new FamilyRental());

            rental.AddRent(new Rental(5, 5, RentTypeEnum.ByHour));
            rental.AddRent(new Rental(1, 60, RentTypeEnum.ByWeek));
            rental.AddRent(new Rental(3, 20, RentTypeEnum.ByDay));
            rental.AddRent(new Rental(7, 20, RentTypeEnum.ByDay));

            Assert.IsTrue(rental.Rentals.Count <= 5);
            Assert.IsTrue(rental.Rentals.Count >= 3);
            Assert.IsTrue(rental.CalculateTotal() == (5*5 + 1*60 + 3*20 + 7*20));
        }
    }
}
