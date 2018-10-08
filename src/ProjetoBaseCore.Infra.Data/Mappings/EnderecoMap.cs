using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBaseCore.Domain.Entities;
using ProjetoBaseCore.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Infra.Data.Mappings
{
        public class EnderecoMap : IEntityTypeConfiguration<Endereco>
        {
            public void Configure(EntityTypeBuilder<Endereco> builder)
            {
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnType("varchar(150)");

                builder.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)");

                builder.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                builder.Property(e => e.CEP)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnType("varchar(8)");

                builder.Property(e => e.Complemento)
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                builder.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                builder.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                builder.Ignore(e => e.ValidationResult);
                builder.Ignore(e => e.CascadeMode);

                builder.ToTable("Endereco");
            }
        }
}
