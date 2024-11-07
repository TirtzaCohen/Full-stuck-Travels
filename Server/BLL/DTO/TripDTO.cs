using System;
using System.Collections.Generic;

namespace BLL.DTO;

public class TripDTO
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

    public String? NameType { get; set; }    

    public bool? Need_a_medic { get; set; }
}
