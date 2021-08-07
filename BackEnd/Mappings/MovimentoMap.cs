using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
            public class MovimentoMap : IEntityTypeConfiguration<Movimentos>
            {
                        public void Configure(EntityTypeBuilder<Movimentos> builder)
                        {
                                    builder.ToTable("Movimentos");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                          
                                           .HasColumnType("BIGINT");
                                    builder.Property(x => x.data)
                                            .IsRequired()
                                            .HasColumnType("DATETIME");
                                    builder.Property(x => x.hora)
                                           .IsRequired()
                                           .HasMaxLength(11)
                                           .HasColumnType("VARCHAR(11)");
                                    builder.Property(x => x.valor)
                                           .IsRequired()
                                           .HasMaxLength(10)
                                           .HasColumnType("float");
                                    builder.Property(x => x.cartao)
                                           .IsRequired()
                                           .HasMaxLength(12)
                                           .HasColumnType("VARCHAR(12)");
                                    builder.Property(x => x.transacaoId)
                                           .IsRequired()
                                           .HasColumnType("BIGINT");
                                    builder.Property(x => x.lojaId)
                                          
                                           .HasColumnType("BIGINT");

                        }
            }
}