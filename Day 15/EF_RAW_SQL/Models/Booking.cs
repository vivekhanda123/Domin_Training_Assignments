using System;
using System.Collections.Generic;

namespace EF_RAW_SQL.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? RoomId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }

        public virtual Room? Room { get; set; }
    }
}
