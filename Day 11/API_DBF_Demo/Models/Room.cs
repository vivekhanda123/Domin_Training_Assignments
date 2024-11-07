﻿using System;
using System.Collections.Generic;

namespace API_DBF_Demo.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public string? RoomType { get; set; }
        public bool? Availability { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}