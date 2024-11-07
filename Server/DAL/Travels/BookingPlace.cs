using System;
using System.Collections.Generic;

namespace DAL.Travels;

public partial class BookingPlace
{
    public int BookingCode { get; set; }

    public int? UserCode { get; set; }

    public DateTime? BookingDate { get; set; }

    public TimeSpan? BookingTime { get; set; }

    public int? TripCode { get; set; }

    public int? NumberOfPlaces { get; set; }

    public virtual Trip? TripCodeNavigation { get; set; }

    public virtual User? UserCodeNavigation { get; set; }
}
