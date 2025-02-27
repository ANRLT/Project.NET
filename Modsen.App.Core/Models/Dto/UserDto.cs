﻿using System.Collections.Generic;

namespace Modsen.App.Core.Models.Dto
{
    //Data Transfer Object
    //Нам нужны dto для всех моделей?
    public class UserDto 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        //public List<Booking> Bookings { get; set; }

        // Does we need     public string Password { get; set; } ? No, We already have it
        // Does we need     public string RepeatPassword { get; set; } ?
    }
}