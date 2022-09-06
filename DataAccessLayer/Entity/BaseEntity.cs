using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedUser { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateUser { get; set; }
    }
}
