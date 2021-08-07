using System;

namespace BackEnd.Models
{
    public class Movimentos:Base
    {
      
        public DateTime data{get;set;}
        public string hora{get;set;}
        public double valor{get;set;}
        public string cartao{get;set;}
        public long transacaoId{get;set;}
        public long lojaId{get;set;}
        public virtual Lojas loja{get;set;}   
        public virtual Transacoes transacao{get;set;}   
    }
}