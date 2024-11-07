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
    public class TravelTypeDal:ITravelTypeDal
    {
        TravelsContext db;
        public TravelTypeDal(TravelsContext db)
        {
            this.db = db;
        }

        public int add(TravelType t)
        {
            db.Add(t);
            db.SaveChanges();
            return t.TypeCode;
        }

        public bool delete(int code)
        {
            TravelType? travelType = db.TravelTypes.FirstOrDefault(x=>x.TypeCode== code);    
            if (travelType != null) 
            {
                db.TravelTypes.Remove(travelType);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public TravelType get(int code)
        {
            return db.TravelTypes.Include(x => x.Trips).First(x=>x.TypeCode == code); 
        }

        public List<TravelType> get_all()
        {
            return db.TravelTypes.Include(x=>x.Trips).ToList();
        }
    }
}
