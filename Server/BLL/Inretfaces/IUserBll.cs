using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Inretfaces
{
    public interface IUserBll
    {
        List<UserDTO> get_all();
        UserDTO get(string email, string login_Password);
        int add(UserDTO user);
        bool update(UserDTO user);
        bool delete(UserDTO user);
        List<TripDTO> get_all_trips(int code);
    }
}
