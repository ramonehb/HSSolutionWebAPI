﻿// <auto-generated />
using System;
using HSSolution.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HSSolution.Persistence.Migrations
{
    [DbContext(typeof(BaseDataContext))]
    [Migration("20230809022949_newDbHSSolution")]
    partial class newDbHSSolution
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HSSolution.Domain.Cobranca", b =>
                {
                    b.Property<int>("IdCobranca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Cobranca");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCobranca"));

                    b.Property<int>("IdFatura")
                        .HasColumnType("int")
                        .HasColumnName("ID_Fatura");

                    b.Property<int?>("NrParcela")
                        .HasColumnType("int")
                        .HasColumnName("NR_Parcela");

                    b.Property<decimal?>("VlBruto")
                        .HasColumnType("numeric(16, 2)")
                        .HasColumnName("VL_Bruto");

                    b.Property<decimal?>("VlLiquido")
                        .HasColumnType("numeric(16, 2)")
                        .HasColumnName("VL_Liquido");

                    b.HasKey("IdCobranca")
                        .HasName("PK__Cobranca__AA56A536FF00E511");

                    b.HasIndex(new[] { "IdFatura" }, "IX_Cobranca_001");

                    b.ToTable("Cobranca", (string)null);
                });

            modelBuilder.Entity("HSSolution.Domain.Fatura", b =>
                {
                    b.Property<int>("IdFatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Fatura");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFatura"));

                    b.Property<DateTime?>("DtCadastro")
                        .HasColumnType("datetime")
                        .HasColumnName("DT_Cadastro");

                    b.Property<string>("NmSubEstipulante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NM_SubEstipulante");

                    b.HasKey("IdFatura")
                        .HasName("PK__Fatura__9F2CBCBD4E544CC8");

                    b.ToTable("Fatura", (string)null);
                });

            modelBuilder.Entity("HSSolution.Domain.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerfil"));

                    b.Property<string>("NmDescricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfils");
                });

            modelBuilder.Entity("HSSolution.Domain.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtExpiracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaTentativa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimoAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("FlHabilitado")
                        .HasColumnType("bit");

                    b.Property<int?>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<int?>("IdPerfilNavigationIdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NrTentativa")
                        .HasColumnType("int");

                    b.Property<int?>("NrUltimoAcesso")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex(new[] { "IdPerfilNavigationIdPerfil" }, "IX_Usuarios_IdPerfilNavigationIdPerfil");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("HSSolution.Domain.Cobranca", b =>
                {
                    b.HasOne("HSSolution.Domain.Fatura", "IdFaturaNavigation")
                        .WithMany("Cobrancas")
                        .HasForeignKey("IdFatura")
                        .IsRequired()
                        .HasConstraintName("FK_Cobranca_Fatura");

                    b.Navigation("IdFaturaNavigation");
                });

            modelBuilder.Entity("HSSolution.Domain.Usuario", b =>
                {
                    b.HasOne("HSSolution.Domain.Perfil", "IdPerfilNavigationIdPerfilNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPerfilNavigationIdPerfil");

                    b.Navigation("IdPerfilNavigationIdPerfilNavigation");
                });

            modelBuilder.Entity("HSSolution.Domain.Fatura", b =>
                {
                    b.Navigation("Cobrancas");
                });

            modelBuilder.Entity("HSSolution.Domain.Perfil", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
