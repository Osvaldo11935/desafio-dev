using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Transacoes:Base
    {
     
        public string descricao{get;set;}
        public string natureza{get;set;}
        public string sinal{get;set;}
    }
}