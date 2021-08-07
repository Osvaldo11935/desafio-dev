using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Helper;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories
{
    public class RepositoryBase<T> :IRepositoryBase<T> where T: Base 
    {
        private readonly BackEndContext _context;
        public RepositoryBase(BackEndContext context){
          _context= context;
        }
        public async Task<T> adicionar(T model){
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<T> actualizar(T model){
             _context.Entry(model).State=EntityState.Modified;
             await _context.SaveChangesAsync();
             return model;
        }
        public async Task remover(long id){
            var obj=get(id);
             if(obj!=null)
             {
                 _context.Remove(obj);
                 await _context.SaveChangesAsync();
             }
        }
        public async Task<T> get(long id){
          var obj= await get();
          return obj.Where(r=>r.id==id).FirstOrDefault();
        }
        public async Task<T> get(string search){
          var obj= await get();
          return obj.Where(r=>r.ContainValue(search)).FirstOrDefault();
        }
        public async Task<List<T>> get(){
            return await _context.Set<T>()
                           .AsNoTracking()
                           .ToListAsync();
        }
    }
}