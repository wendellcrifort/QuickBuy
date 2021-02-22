using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.DataPedido)
                .IsRequired();

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasMaxLength(11);

            builder
                .Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(p => p.Bairro)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(p => p.Rua)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(p => p.Numero)
                .IsRequired();

            builder
                .Property(p => p.Complemento)
                .IsRequired();

            builder
                .HasOne(p => p.FormaPagamento);

            builder
                .HasOne(p => p.Usuario);

            builder
                .HasMany(p => p.ItensPedido)
                .WithOne(i => i.Pedido);            
        }        
    }
}
