using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IMovimentoRepository :IRepositoryBase<Movimentos>
    {
         Task<List<Movimentos>> getMovimento();
    }
}