using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBaseService<RsDTO, T, RqDTO>
    {
        IEnumerable<RsDTO> GetAll();
        RsDTO GetById(int id);
        RsDTO Insert(RqDTO dto);
        void Update(RqDTO dto);
        int Delete(int id);

        //IEnumerable<RsDTO> GetByFilter(Expression<Func<T, bool>> filter);

        //Response RsDTO->cavab
        //Request  RqDTO->Sorgu
    }
}
