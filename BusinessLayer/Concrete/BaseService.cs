using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BaseService<RqDTO, T, RsDTO> : IBaseService<RsDTO, T, RqDTO>
        where T : BaseEntity
    {

        protected readonly IMapper _mapper;
        protected readonly ApplicationDBContext _dBContext;
        protected readonly DbSet<T> _dbSet;

        public BaseService(IMapper mapper, ApplicationDBContext dBContext)
        {
            _mapper = mapper;
            _dBContext = dBContext;
            _dbSet = dBContext.Set<T>();
        }

        public int Delete(int id)
        {
            var ent = _dbSet.Find(id);
            _dbSet.Remove(ent);
            _dBContext.SaveChanges();
            return ent.ID;
        }

        public IEnumerable<RsDTO> GetAll()
        {
            var ent = _dbSet.ToList();
            var rsdto = _mapper.Map<IEnumerable<RsDTO>>(ent);
            return rsdto;
        }

        public RsDTO GetById(int id)
        {
            var ent = _dbSet.Find(id);
            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public RsDTO Insert(RqDTO dto)
        {
            var ent = _mapper.Map<T>(dto);
            ent.CreatedAt = DateTime.Now;

            _dbSet.Add(ent);
            _dBContext.SaveChanges();

            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public void Update(RqDTO dto)
        {
            var ent = _mapper.Map<T>(dto);
            ent.UpdateAt = DateTime.Now;

            _dbSet.Update(ent);
            _dBContext.SaveChanges();
        }

        //public IEnumerable<RsDTO> GetByFilter(Expression<Func<T, bool>> filter)
        //{
        //    var ent = _dBContext.Set<T>().Where(filter).ToList();
        //    var rsdto = _mapper.Map<IEnumerable<RsDTO>>(ent);
        //    return rsdto;
        //}
    }
}
