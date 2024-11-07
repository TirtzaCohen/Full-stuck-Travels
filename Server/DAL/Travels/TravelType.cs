using System;
using System.Collections.Generic;

namespace DAL.Travels;

public partial class TravelType
{
    public int TypeCode { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
