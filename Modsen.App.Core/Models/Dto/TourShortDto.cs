using System;
using System.Collections.Generic;

namespace Modsen.App.Core.Models.Dto
{
    //Do I write this file correct?    

    public class TourShortDto 
    {
        public string Name { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        //public TourType TourType { get; set; }

        //public Transport Transport { get; set; }

        //public List<Booking> Bookings { get; set; }
    }
}