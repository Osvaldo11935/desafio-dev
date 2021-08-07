using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Interface;
using BackEnd.Models;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BackEnd.Controllers
{
            [ApiController]
            [Route("[controller]")]
            public class gerarMovimentoController : ControllerBase
            {
                        private readonly IWebHostEnvironment _appEnv;
                        private readonly MovimentoRepository _movRepo;
                        private readonly PessoaRepository _pessoaRepo;
                        private readonly LojaRepository _lojaRepo;
                        private readonly TransacaoRepository _traRepo;
                        private readonly IParserArquivo _parserArquivo;
                        private readonly ILogger<gerarMovimentoController> _logger;

                        public gerarMovimentoController(ILogger<gerarMovimentoController> logger, IWebHostEnvironment appEnv, IParserArquivo parserArquivo, MovimentoRepository movRepo, PessoaRepository pessoaRepo, LojaRepository lojaRepo, TransacaoRepository traRepo)
                        {
                                    _pessoaRepo = pessoaRepo;
                                    _traRepo = traRepo;
                                    _lojaRepo = lojaRepo;
                                    _movRepo = movRepo;
                                    _parserArquivo = parserArquivo;
                                    _appEnv = appEnv;
                                    _logger = logger;
                        }

                        [HttpPost]
                        public async Task<string> upload(List<IFormFile> arquivos)
                        {
                                   //metodo responsavel por pegar os dados do arquivo que foi enviado 
                                    var dadostr = _parserArquivo.fileConfig(arquivos);
                                    //limpar o espaço vazio se exister na string do texto
                                    dadostr = dadostr.TrimEnd();
                                   // verificando se o texto é valido para poder extrair os dados.
                                    if (dadostr != null && dadostr != "")
                                    {
                                                //Extraido os dados do texto
                                                var movimentos = _parserArquivo.extrarDados(dadostr);
                                                int i = 0;
                                                //Fazendo a Inserção do movimento na base de dados
                                                foreach (var objMov in movimentos)
                                                {
                                                            //Pegando o tipo de transação do dado
                                                            var transacao = await _traRepo.get(objMov.transacaoId);
                                                            //Inserido os dados do proprietario caso ele não exista
                                                            var pessoa = await _pessoaRepo.addPessoa(new Pessoas()
                                                            {
                                                                        id = i + 1,
                                                                        nome = objMov.loja.proprietario.nome,
                                                                        cpf = objMov.loja.proprietario.cpf
                                                            });
                                                            //Inserido os dados da loja caso ela não exista
                                                            var loja = await _lojaRepo.addLoja(new Lojas()
                                                            {
                                                                        id = i + 1,
                                                                        proprietarioId = pessoa.id,
                                                                        nome = objMov.loja.nome
                                                            });
                                                            //Inserido os dados do movimento 
                                                            await _movRepo.adicionar(new Movimentos()
                                                            {
                                                                        id = i + 1,
                                                                        valor = objMov.valor,
                                                                        cartao = objMov.cartao,
                                                                        data = objMov.data,
                                                                        hora = objMov.hora,
                                                                        transacaoId = transacao.id,
                                                                        lojaId = loja.id
                                                            });
                                                            i++;
                                                }
                                    }
                                    else
                                      return "Ficheiro invalido";
                                    return "Ficheiro carregado com suceeso";
                        }
                        [HttpGet]
                        public async Task<List<Movimentos>> get()
                        {
                            return await _movRepo.getMovimento();
                        }
            
            }
}