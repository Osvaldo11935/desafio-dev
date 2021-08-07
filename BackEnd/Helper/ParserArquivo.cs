using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Helper
{
            public class ParserArquivo : IParserArquivo
            {
                        
                        public List<Movimentos> extrarDados(string strdata)
                        {

                                    var dados = strdata.Split("\n");
                                    var movimnetos = new List<Movimentos>();
                                    foreach (var data in dados)
                                    {
                                                if (data != "")
                                                {
                                                            movimnetos.Add(new Movimentos()
                                                            {
                                                                        id = 1,
                                                                        valor = Double.Parse(data.StartString(10, 10)) / 100,
                                                                        data = DateTime.Parse($"{data.StartString(1, 8).StartString(0, 4)}-{data.StartString(1, 8).StartString(4, 2)}-{data.StartString(1, 8).StartString(6, 2)}"),
                                                                        hora = $"{data.StartString(42, 6).StartString(0, 2)}:{data.StartString(42, 6).StartString(2, 2)}:{data.StartString(42, 6).StartString(4, 2)}",
                                                                        cartao = data.StartString(30, 12),
                                                                        transacaoId = long.Parse(data.StartString(0, 1)),
                                                                        loja = new Lojas()
                                                                        {
                                                                                    nome = data.StartString(62, 19),
                                                                                    proprietario = new Pessoas()
                                                                                    {
                                                                                                nome = data.StartString(48, 14).TrimEnd(),
                                                                                                cpf = data.StartString(19, 11)
                                                                                    }
                                                                        }
                                                            });
                                                }
                                    }
                                    return movimnetos;
                        }
                        public string fileConfig(List<IFormFile> arquivos)
                        {
                                    var extensaoArquivo = new Dictionary<string,string>()
                                    {
                                       {"text/plain","txt"}
                                    };
                                    string strBase64 = "";
                                    foreach (var arquivo in arquivos)
                                    {
                                                var isvalid = extensaoArquivo.FirstOrDefault(e=>e.Key==arquivo.ContentType).Value;
                                               
                                                if (isvalid!=null)
                                                {

                                                      using (var ms = new MemoryStream())
                                                      {
                                                                  arquivo.CopyTo(ms);
                                                                  var fileBytes = ms.ToArray();
                                                                  strBase64 = Encoding.UTF8.GetString(fileBytes);
                                                                  //Convert.ToBase64String(fileBytes);
                                                      }

                                                }

                                    }
                                    return strBase64;

                        }
            }
}