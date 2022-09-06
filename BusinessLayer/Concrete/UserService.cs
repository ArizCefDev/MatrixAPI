using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DTO.DTOEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
        public UserService(IMapper mapper, ApplicationDBContext dBContext)
            : base(mapper, dBContext)
        {
        }

        public bool Login(UserDTO p)
        {        
            return true;
        }

        //public IEnumerable<UserDTO> GetFilterID(int id)
        //{
        //    return GetByFilter(x => x.ID == id);
        //}

        //public IEnumerable<UserDTO> GetSearch(string s)
        //{
        //    return GetByFilter(x => x.UserName.Contains(s)); ;
        //}
    }
}
