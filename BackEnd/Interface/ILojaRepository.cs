using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface ILojaRepository:IRepositoryBase<Lojas>
    {
         Task<Lojas> addLoja(Lojas model);
    }
}