using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace BackEnd.Models
{
    public class Pessoas:Base
    {
        public string nome{get;set;}
        public string cpf{get;set;}
        
    }
}