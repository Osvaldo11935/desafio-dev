using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories
{
    public class MovimentoRepository:RepositoryBase<Movimentos>,IMovimentoRepository
    {
        private readonly BackEndContext _context;
        public MovimentoRepository( BackEndContext context):base(context)
        {
            _context=context;
        }
        public async Task<List<Movimentos>> getMovimentoPornatureza()
        {

              var mov=new List<Movimentos>();
              var movimentos= await _context.movimentos
                                           .Include(e=>e.loja.proprietario)
                                           .Include(e=>e.transacao)
                                           .ToListAsync();
             
             movimentos.ForEach(e=>{
              if(mov.Count>0)
              {
                 var isExist=mov.Where(o=>o.loja.proprietario.cpf==e.loja.proprietario.cpf && o.transacao.natureza==e.transacao.natureza).FirstOrDefault();
                 if(isExist!=null)
                 {
                     mov.ForEach(l=>{
                         l.valor+=isExist.valor;
                     });
                 }
                 else
                  mov.Add(e);
              }
              
              else
               mov.Add(e);
            });
             return mov.OrderBy(r=>r.loja.proprietario.cpf).ToList();
        }
         public async Task<List<Movimentos>> getMovimento()
        {

              var mov=new List<Movimentos>();
              var movimentos= await _context.movimentos
                                           .Include(e=>e.loja.proprietario)
                                           .Include(e=>e.transacao)
                                           .ToListAsync();
             
             return movimentos.OrderBy(r=>r.loja.proprietario.cpf).ToList();
        }
    }
}