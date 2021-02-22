using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.ObjetoDeValor;

namespace QuickBuy.Repositorio.Config
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(i => i.Descricao)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
