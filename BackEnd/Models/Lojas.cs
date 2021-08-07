using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Lojas:Base
    {
        
        public string nome{get;set;}
        public long proprietarioId{get;set;}
        public virtual Pessoas proprietario{get;set;}   
    }
}