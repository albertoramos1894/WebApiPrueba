using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.DB.Models;

public partial class EmpresaContext : DbContext
{
    public EmpresaContext()
    {
    }

    public EmpresaContext(DbContextOptions<EmpresaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beneficiario> Beneficiarios { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<LoginDispositivo> LoginDispositivos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=Empresa; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beneficiario>(entity =>
        {
            entity.HasKey(e => e.IdBeneficiario);

            entity.ToTable("Beneficiario");

            entity.Property(e => e.IdBeneficiario)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_beneficiario");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Apellido_materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_nacimiento");
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_empleado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithOne(p => p.Beneficiario)
                .HasForeignKey<Beneficiario>(d => d.IdBeneficiario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beneficiario_Empleado");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("Id_empleado");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaContratación).HasColumnType("date");
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.IdBeneficiario).HasColumnName("Id_beneficiario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PuestoTrabajo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("money");
            entity.Property(e => e.Usuario)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdBeneficiario)
                .HasConstraintName("FK_Empleado_beneficiario");
        });

        modelBuilder.Entity<LoginDispositivo>(entity =>
        {
            entity.HasKey(e => e.IdLogin);

            entity.ToTable("LoginDispositivo");

            entity.Property(e => e.IdDispositivo).HasColumnName("Id_dispositivo");
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
