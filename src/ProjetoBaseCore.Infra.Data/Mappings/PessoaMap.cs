using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBaseCore.Domain.Entities;
using ProjetoBaseCore.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Infra.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DataNascimento)
                .HasColumnType("datetime");

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Telefone)
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Pessoa)
                .HasForeignKey<Pessoa>(e => e.EnderecoId)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);
            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Pessoa");
        }
    }
}
