using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IPessoaRepository :IRepositoryBase<Pessoas>
    {
         Task<Pessoas> addPessoa(Pessoas model);
    }
    
}