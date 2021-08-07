using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
    public class LojaMap : IEntityTypeConfiguration<Lojas>
    {
         public void Configure(EntityTypeBuilder<Lojas> builder)
                        {
                                    builder.ToTable("Lojas");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                        
                                           .HasColumnType("BIGINT");
                                    builder.Property(x => x.nome)
                                           .IsRequired()
                                           .HasMaxLength(14)
                                           .HasColumnType("VARCHAR(14)");

                        }
    }
}