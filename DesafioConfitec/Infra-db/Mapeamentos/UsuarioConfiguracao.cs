using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_db.Mapeamentos
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios"); 

            builder.HasKey(u => u.Id);

            builder.HasAlternateKey(u => u.Email);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(u => u.Email)
                .IsRequired()                
                .HasMaxLength(100); 

            builder.Property(u => u.DataNascimento)
                .IsRequired();            

            builder.Property(u => u.Escolaridade)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .IsRequired();

            builder.Property(u => u.DataModificacao)
                .IsRequired();

        }
    }
}
