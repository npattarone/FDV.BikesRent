using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDV.BikesRent
{
    public class Rental
    {
        public Rental() { }

        public Rental(int time, decimal price, RentTypeEnum type)
        {
            Time = time;
            Price = price;
            RentType = type;
        }

        public int Time { get; set; }

        public decimal Price { get; set; }

        public RentTypeEnum RentType { get; set; }
    }

    public enum RentTypeEnum
    {
        ByHour = 0,
        ByDay,
        ByWeek
    }
}
