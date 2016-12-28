using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDV.BikesRent
{
    public class RentalContext
    {
        private RentalStrategy _strategy;

        public IList<Rental> Rentals {
            get
            {
                if (_strategy != null)
                    return _strategy.Rentals;
                else
                    return null;
            }
        }

        public void SetRentalStrategy(RentalStrategy strategy)
        {
            _strategy = strategy;
        }

        public void AddRent(Rental rent)
        {
            _strategy.AddRent(rent);
        }

        public decimal CalculateTotal()
        {
            return _strategy.CalculateTotal();
        }
    }
}
