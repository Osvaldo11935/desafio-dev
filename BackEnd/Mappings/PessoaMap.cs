using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BackEnd.Models;

namespace BackEnd.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoas>
    {
         public void Configure(EntityTypeBuilder<Pessoas> builder)
                        {
                                    builder.ToTable("Pessoas");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                          
                                          
                                           .HasColumnType("BIGINT");
                                    builder.Property(x => x.nome)
                                           .IsRequired()
                                           .HasMaxLength(14)
                                           .HasColumnType("VARCHAR(14)");
                                    builder.Property(x => x.cpf)
                                           .IsRequired()
                                            .HasMaxLength(11)
                                           .HasColumnType("VARCHAR(11)");
                                   

                        }
    }
}