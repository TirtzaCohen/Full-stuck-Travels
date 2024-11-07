using System;
using System.Collections.Generic;

namespace DAL.Travels;

public partial class Trip
{
    public int TripCode { get; set; }

    public string? TripDestination { get; set; }

    public int? TypeCode { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? DepartureTime { get; set; }

    public int? TripDurationHours { get; set; }

    public int? NumberOfAvailablePlaces { get; set; }

    public decimal? Price { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<BookingPlace> BookingPlaces { get; set; } = new List<BookingPlace>();

    public virtual TravelType? TypeCodeNavigation { get; set; }
}
