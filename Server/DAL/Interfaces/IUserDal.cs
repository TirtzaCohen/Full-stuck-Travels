using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDal
    {
        List<User> get_all();
        User get(string email, string login_password);
        int add(User user);
        bool delete(int code);
        bool update(User user);

    }
}
