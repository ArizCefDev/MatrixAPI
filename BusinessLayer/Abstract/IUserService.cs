using DataAccessLayer.Entity;
using DTO.DTOEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IBaseService<UserDTO, User, UserDTO>
    {
        bool Login(UserDTO p);

        //IEnumerable<UserDTO> GetFilterID(int id);
        //IEnumerable<UserDTO> GetSearch(string s);
    }
}
