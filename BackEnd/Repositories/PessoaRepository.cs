using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;
namespace BackEnd.Repositories
{
    public class PessoaRepository:RepositoryBase<Pessoas>,IPessoaRepository
    {
        private readonly BackEndContext _context;
        public PessoaRepository( BackEndContext context):base(context)
        {
            _context=context;
        }
        public async Task<Pessoas> addPessoa(Pessoas model)
        {
            var pessoa= await get(model.cpf);
            if(pessoa==null)
              return await adicionar(model);
            else
              return pessoa;
        } 
        
    }
}