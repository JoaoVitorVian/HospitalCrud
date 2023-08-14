using HospitalCrud.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class PacienteMap : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Paciente");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .UseIdentityColumn()
               .HasColumnType("BIGINT");

        builder.Property(x => x.NomeCompleto)
               .IsRequired()
               .HasMaxLength(80)
               .HasColumnName("name")
               .HasColumnType("VARCHAR(80)");

        builder.Property(x => x.NumeroCelular)
               .IsRequired()
               .HasMaxLength(30)
               .HasColumnName("password")
               .HasColumnType("VARCHAR(30)");

        builder.Property(x => x.Endereco)
               .IsRequired()
               .HasMaxLength(180)
               .HasColumnName("email")
               .HasColumnType("VARCHAR(180)");

        builder.Property(x => x.FotoBase64)
               .HasColumnName("FotoBase64")
               .HasColumnType("NVARCHAR(MAX)"); 
    }
}
