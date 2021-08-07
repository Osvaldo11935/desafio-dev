using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
         private readonly TransacaoRepository _traRepo;
         private readonly ILogger<gerarMovimentoController> _logger;
        public TransacaoController(ILogger<gerarMovimentoController> logger,TransacaoRepository traRepo)
        {
          
            _traRepo=traRepo;
            _logger = logger;
        }

     [HttpPost]
      public  async Task<List<Transacoes>> add(List<Transacoes> model)
      {
          foreach(var obj in model)
            await _traRepo.adicionar(obj);
          return model;
      }
      [HttpGet]
       public  async Task<List<Transacoes>> get()
       {
           return await get();
       }
       [HttpGet("{search}")]
       public  async Task<Transacoes> get(string search)
       {
           return await get(search);
       }
    }
}