using BackEnd.Mappings;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DbConfig
{
    public class BackEndContext:DbContext
    {
        public BackEndContext(DbContextOptions<BackEndContext> option):base(option)
        {}
        public DbSet<Pessoas> pessoas{get;set;}
        public DbSet<Movimentos> movimentos{get;set;}
        public DbSet<Lojas> lojas{get;set;}
        public DbSet<Transacoes> transacoes{get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovimentoMap());
            builder.ApplyConfiguration(new PessoaMap());
            builder.ApplyConfiguration(new TransacaoMap());
            builder.ApplyConfiguration(new LojaMap());
        }
    }
}