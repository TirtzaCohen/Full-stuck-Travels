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
    public class UserDal : IUserDal
    {
        TravelsContext db;
        public UserDal(TravelsContext db)
        {
            this.db = db;
        }
        public int add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.UserCode;
                
        }

        public bool delete(int code)
        {
            User? user = db.Users.FirstOrDefault(x=>x.UserCode == code);  
            if (user != null) 
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public User? get(string email, string login_password)
        {
           
           return db.Users.Include(x => x.BookingPlaces).FirstOrDefault(x=>x.Email==email&&x.LoginPassword==login_password);      
         }

        public List<User> get_all()
        {
            return db.Users.Include(x=>x.BookingPlaces).ToList();   
        }

        public bool update(User user)
        {
            User? u = get_all().FirstOrDefault(x => x.UserCode == user.UserCode);
            if(u!=null)
            {

                u.Name = user.Name;
                u.Family = user.Family;
                u.Phone = user.Phone;
                u.Email = user.Email;
                u.LoginPassword = user.LoginPassword;
                u.FirstAidCertificate = user.FirstAidCertificate;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
