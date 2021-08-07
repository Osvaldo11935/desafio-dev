using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;

namespace BackEnd.Repositories
{
    public class TransacaoRepository:RepositoryBase<Transacoes>,ITransacaoRepository
    {
        private readonly BackEndContext _context;
        public TransacaoRepository( BackEndContext context):base(context)
        {
            _context=context;
        }
        
    }
}