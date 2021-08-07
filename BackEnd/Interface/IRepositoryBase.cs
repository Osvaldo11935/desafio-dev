using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IRepositoryBase<T> where T:Base
    {
          Task<T> adicionar(T model);
          Task<T> actualizar(T model);
          Task remover(long id);
          Task<T> get(long id);
          Task<List<T>> get();
          Task<T> get(string search);
    }
}