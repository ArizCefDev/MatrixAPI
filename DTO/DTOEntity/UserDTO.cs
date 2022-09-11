using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }///
        public string Password { get; set; }
        public string PasswordHash { get; set; }//
    }
}
