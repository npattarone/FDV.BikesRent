using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDV.BikesRent
{
    public abstract class RentalStrategy
    {
        public IList<Rental> Rentals { get; set; }

        public abstract decimal CalculateTotal();

        public abstract void AddRent(Rental rent);
    }

    public class CommonRental : RentalStrategy
    {
        public override void AddRent(Rental rent)
        {
            if (Rentals == null)
                Rentals = new List<Rental>();

            if (!Rentals.Any())
            {
                Rentals.Add(rent);
            }
        }
        

        public override decimal CalculateTotal()
        {
            if (Rentals != null && Rentals.Count == 1)
            {
                var rental = Rentals.First();

                return rental.Price * rental.Time;
            }
            else
                return -1;
        }
    }

    public class FamilyRental : RentalStrategy
    {
        public override void AddRent(Rental rent)
        {
            if (Rentals == null)
                Rentals = new List<Rental>();

            if (Rentals.Count < 5)
            {
                Rentals.Add(rent);
            }
        }


        public override decimal CalculateTotal()
        {
            decimal total = 0;

            if (Rentals != null && (Rentals.Count >= 3 && Rentals.Count <= 5))
            {
                foreach (var rent in Rentals)
                {
                    total += rent.Price * rent.Time;
                }

                return total;
            }
            else {
                return -1;
            }
        }
    }

}
