using System;
using System.Collections.Generic;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Data;

public partial class SistemaRrhhContext : DbContext
{
    public SistemaRrhhContext()
    {
    }

    public SistemaRrhhContext(DbContextOptions<SistemaRrhhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencia { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EvaluacionDesempeno> EvaluacionDesempenos { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asistenc__3214EC079485D30E");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asistenci__Emple__4316F928");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cargo__3214EC0721FD1E19");

            entity.ToTable("Cargo");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.SalarioBase).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contrato__3214EC079E281EC0");

            entity.ToTable("Contrato");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contrato__Emplea__403A8C7D");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departam__3214EC0761F11BC9");

            entity.ToTable("Departamento");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Presupuesto).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC0700716A1A");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.Email, "UQ__Empleado__A9D105349DBE8487").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__CargoI__3D5E1FD2");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DepartamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__Depart__3C69FB99");
        });

        modelBuilder.Entity<EvaluacionDesempeno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evaluaci__3214EC07BC8C1015");

            entity.ToTable("EvaluacionDesempeno");

            entity.HasOne(d => d.Empleado).WithMany(p => p.EvaluacionDesempenos)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluacio__Emple__4E88ABD4");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nomina__3214EC07A7CB722C");

            entity.ToTable("Nomina");

            entity.Property(e => e.Deducciones).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalarioNeto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nomina__Empleado__45F365D3");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permiso__3214EC07FED0AEB1");

            entity.ToTable("Permiso");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente");

            entity.Property(e => e.FechaSolicitud).HasDefaultValueSql("now()");

            entity.Property(e => e.Motivo).HasMaxLength(255);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permiso__Emplead__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}