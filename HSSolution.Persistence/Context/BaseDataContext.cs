using System;
using System.Collections.Generic;
using HSSolution.Domain;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence.Context;

public partial class BaseDataContext : DbContext
{
    public BaseDataContext()
    {
    }

    public BaseDataContext(DbContextOptions<BaseDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cobranca> Cobrancas { get; set; }

    public virtual DbSet<Fatura> Faturas { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cobranca>(entity =>
        {
            entity.HasKey(e => e.IdCobranca).HasName("PK__Cobranca");

            entity.ToTable("Cobranca");

            entity.HasIndex(e => e.IdFatura, "IX_Cobranca_001");

            entity.Property(e => e.IdCobranca).HasColumnName("ID_Cobranca");
            entity.Property(e => e.IdFatura).HasColumnName("ID_Fatura");
            entity.Property(e => e.NrParcela).HasColumnName("NR_Parcela");
            entity.Property(e => e.VlBruto)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("VL_Bruto");
            entity.Property(e => e.VlLiquido)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("VL_Liquido");

            entity.HasOne(d => d.IdFaturaNavigation).WithMany(p => p.Cobrancas)
                .HasForeignKey(d => d.IdFatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cobranca_Fatura");
        });

        modelBuilder.Entity<Fatura>(entity =>
        {
            entity.HasKey(e => e.IdFatura).HasName("PK__Fatura");

            entity.ToTable("Fatura");

            entity.Property(e => e.IdFatura).HasColumnName("ID_Fatura");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DT_Cadastro");
            entity.Property(e => e.NmSubEstipulante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_SubEstipulante");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.IdPerfil);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.HasIndex(e => e.IdPerfilNavigationIdPerfil, "IX_Usuarios_IdPerfilNavigationIdPerfil");

            entity.HasOne(d => d.IdPerfilNavigationIdPerfilNavigation).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdPerfilNavigationIdPerfil);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
