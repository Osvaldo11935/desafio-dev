using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacoes>
    {
         public void Configure(EntityTypeBuilder<Transacoes> builder)
                        {
                                    builder.ToTable("Transacoes");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                           .UseIdentityColumn()
                                           .HasColumnType("BIGINT");
                                    builder.Property(x => x.descricao)
                                           .IsRequired()
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.natureza)
                                           .IsRequired()
                                            .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.sinal)
                                           .IsRequired()
                                            .HasMaxLength(2)
                                           .HasColumnType("VARCHAR(2)");
                                   

                        }
    }
}