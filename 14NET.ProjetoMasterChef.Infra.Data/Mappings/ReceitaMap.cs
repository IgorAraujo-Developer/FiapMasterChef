using _14NET.ProjetoMasterChef.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _14NET.ProjetoMasterChef.Infra.Data.Mappings
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.Property(c => c.Id)
                 .HasColumnName("Id");

            builder.Property(c => c.Titulo)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Ingredientes)
                .IsRequired();

            builder.Property(c => c.ModoPreparo)
                .IsRequired();               
        }
    }
}
