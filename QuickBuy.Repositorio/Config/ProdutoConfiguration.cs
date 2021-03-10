using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ID);

            builder
                .Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(p => p.NomeArquivo)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
