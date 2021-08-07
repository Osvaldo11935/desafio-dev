using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;
namespace BackEnd.Repositories
{
    public class LojaRepository:RepositoryBase<Lojas>,ILojaRepository
    {
        private readonly BackEndContext _context;
        public LojaRepository( BackEndContext context):base(context)
        {
            _context=context;
        }
        public async Task<Lojas> addLoja(Lojas model)
        {
            var loja= await get(model.nome);
            if(loja==null)
              return await adicionar(model);
            else
              return loja;
        } 
    }
}