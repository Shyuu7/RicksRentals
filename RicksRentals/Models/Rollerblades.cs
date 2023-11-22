using System;
using System.Collections.Generic;

namespace RicksRentals.Models
{
    public partial class Rollerblades
    {
        public int BladesId { get; set; }
        public string Brand { get; set; } = null!;
        public string? Model { get; set; }
        public decimal? DailyRate { get; set; }
        public DateTime? RentalDate { get; set; }
    }
}
