﻿
namespace SharedLibrary.DTO
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public int Table { get; set; }
        public DateTime Time { get; set; }
        public int Interval { get; set; }
    }
}
