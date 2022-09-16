using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Helper;
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

        public override UserDTO Insert(UserDTO dto)
        {
            var result = _dBContext.User.Where(x => x.UserName.ToLower() == dto.UserName.ToLower());

            if (result.Count() > 0)
            {
                throw new Exception("User exists");
            }
            dto.Salt = Crypto.GenerateSalt();
            dto.PasswordHash = Crypto.GenerateSHA256Hash(dto.Password, dto.Salt);
            return base.Insert(dto);
        }

        public UserDTO Login(UserDTO dto)
        {
            var result = _dBContext.User.Where(x => x.UserName.ToLower() == dto.UserName.ToLower());

            if (result.Count() == 1)
            {
                var user = result.FirstOrDefault();
                var hash = Crypto.GenerateSHA256Hash(dto.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var model = _mapper.Map<User, UserDTO>(result.First());
                    return model;
                }
                else
                {
                    throw new Exception("Wrong password");
                }
            }
            else
            {
                throw new Exception("User not found");
            }
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
