using System;
using System.Collections.Generic;

namespace BLL.DTO;

public class BookingPlaceDTO
{
    public int BookingCode { get; set; }

    public int? UserCode { get; set; }

    public string? FullNameUser { get; set; }

    public DateTime? BookingDate { get; set; }

    public int TripCode { get; set; }

    public string? Destination { get; set; }

    public DateTime? TripDate { get; set; } 

    public int? NumberOfPlaces { get; set; }

    
}
