﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inventarioAPI.Data;

#nullable disable

namespace inventarioAPI.Migrations
{
    [DbContext(typeof(InventarioContext))]
    [Migration("20240603153557_relaciones")]
    partial class relaciones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("inventarioAPI.Models.Almacen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Almacenes");
                });

            modelBuilder.Entity("inventarioAPI.Models.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CostoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdentificadorTipoInventario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentificadorTipoInventario");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("inventarioAPI.Models.ExistenciasXAlmacen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaUltimaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAlmacen")
                        .HasColumnType("int");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAlmacen");

                    b.HasIndex("IdArticulo");

                    b.ToTable("ExistenciasXAlmacenes");
                });

            modelBuilder.Entity("inventarioAPI.Models.TipoInventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CuentaContable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposInventario");
                });

            modelBuilder.Entity("inventarioAPI.Models.Transaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoTransaccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdArticulo");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("inventarioAPI.Models.Articulo", b =>
                {
                    b.HasOne("inventarioAPI.Models.TipoInventario", "TipoInventario")
                        .WithMany("Articulos")
                        .HasForeignKey("IdentificadorTipoInventario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoInventario");
                });

            modelBuilder.Entity("inventarioAPI.Models.ExistenciasXAlmacen", b =>
                {
                    b.HasOne("inventarioAPI.Models.Almacen", "Almacen")
                        .WithMany("ExistenciasXAlmacenes")
                        .HasForeignKey("IdAlmacen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("inventarioAPI.Models.Articulo", "Articulo")
                        .WithMany("ExistenciasXAlmacenes")
                        .HasForeignKey("IdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Almacen");

                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("inventarioAPI.Models.Transaccion", b =>
                {
                    b.HasOne("inventarioAPI.Models.Articulo", "Articulo")
                        .WithMany("Transacciones")
                        .HasForeignKey("IdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("inventarioAPI.Models.Almacen", b =>
                {
                    b.Navigation("ExistenciasXAlmacenes");
                });

            modelBuilder.Entity("inventarioAPI.Models.Articulo", b =>
                {
                    b.Navigation("ExistenciasXAlmacenes");

                    b.Navigation("Transacciones");
                });

            modelBuilder.Entity("inventarioAPI.Models.TipoInventario", b =>
                {
                    b.Navigation("Articulos");
                });
#pragma warning restore 612, 618
        }
    }
}
