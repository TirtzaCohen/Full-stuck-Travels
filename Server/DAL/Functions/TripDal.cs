using DAL.Interfaces;
using DAL.Travels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class TripDal : ITripDal
    {
        TravelsContext db;
        public TripDal(TravelsContext db) 
        { 
            this.db = db;
        }
        public bool update(Trip trip)
        {
            Trip? t = get_all().FirstOrDefault(x => x.TripCode == trip.TripCode);
            if (t!=null) 
            { 
                t.TripDestination = trip.TripDestination;
                t.TypeCode = trip.TypeCode;
                t.Date = trip.Date;
                t.DepartureTime = trip.DepartureTime;
                t.TripDurationHours = trip.TripDurationHours;
                t.NumberOfAvailablePlaces = trip.NumberOfAvailablePlaces;
                t.Price = trip.Price;
                t.Photo = trip.Photo;
                db.SaveChanges();
                return true;
            }
            return false;
            
        }
        public int add(Trip trip)
        {
            db.Trips.Add(trip);
            db.SaveChanges();
            return trip.TripCode;
        }

        public bool delete(int code)
        {
            Trip? t = db.Trips.FirstOrDefault(x => x.TripCode == code);
            if (t != null)
            {
                db.Trips.Remove(t);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Trip get(int code)
        {
            return db.Trips.Include(x=>x.BookingPlaces).Include(y=>y.TypeCodeNavigation).First(z => z.TripCode == code);
        }

        public List<Trip> get_all()
        {
            return db.Trips.Include(x=>x.BookingPlaces).Include(y=>y.TypeCodeNavigation).ToList();
        }
        public bool add_registration_to_trip(int code)
        {
            Trip t = db.Trips.First(x => x.TripCode == code);
            if (t.NumberOfAvailablePlaces != 0)
            {
                t.NumberOfAvailablePlaces++;
                db.SaveChanges();
                return true;
            }

            return false;
        }



    }
}
