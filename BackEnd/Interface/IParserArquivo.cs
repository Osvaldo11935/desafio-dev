using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Interface
{
    public interface IParserArquivo
    {
        List<Movimentos> extrarDados(string strdata);
        string fileConfig(List<IFormFile> arquivos);
    }
}