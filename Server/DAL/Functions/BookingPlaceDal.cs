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
    public class BookingPlaceDal : IBookingPlaceDal
    {
        TravelsContext db;
        public BookingPlaceDal(TravelsContext db)
        {
            this.db = db;
        }
        public int add(BookingPlace bookingPlace)
        {
            db.BookingPlaces.Add(bookingPlace);
            db.SaveChanges();
            return bookingPlace.BookingCode;
        }

        public bool delete(int code)
        {
            BookingPlace? bookingPlace = db.BookingPlaces.FirstOrDefault(x=>x.BookingCode==code);  
            if (bookingPlace != null)
            {
                db.BookingPlaces.Remove(bookingPlace);  
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public BookingPlace get(int code)
        {
           return db.BookingPlaces.Include(x => x.TripCodeNavigation).Include(y => y.UserCodeNavigation).First(x=>x.BookingCode==code);
            
        }

        public List<BookingPlace> get_all()
        {
            return db.BookingPlaces.Include(x => x.TripCodeNavigation).Include(y => y.UserCodeNavigation).ToList();
        }
    }
}
