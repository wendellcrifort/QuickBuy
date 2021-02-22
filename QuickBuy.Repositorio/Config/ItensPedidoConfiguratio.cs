using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class ItensPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Quantidade)
                .IsRequired();

            builder
                .HasOne(i => i.Produto);

            builder
                .HasOne(i => i.Pedido);
        }
    }
}
