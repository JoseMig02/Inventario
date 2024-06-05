using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaContable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    IdentificadorTipoInventario = table.Column<int>(type: "int", nullable: false),
                    CostoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoInventarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulos_TiposInventario_TipoInventarioId",
                        column: x => x.TipoInventarioId,
                        principalTable: "TiposInventario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExistenciasXAlmacenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlmacen = table.Column<int>(type: "int", nullable: false),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaUltimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlmacenId = table.Column<int>(type: "int", nullable: true),
                    ArticuloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistenciasXAlmacenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExistenciasXAlmacenes_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExistenciasXAlmacenes_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTransaccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticuloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TipoInventarioId",
                table: "Articulos",
                column: "TipoInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasXAlmacenes_AlmacenId",
                table: "ExistenciasXAlmacenes",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasXAlmacenes_ArticuloId",
                table: "ExistenciasXAlmacenes",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ArticuloId",
                table: "Transacciones",
                column: "ArticuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistenciasXAlmacenes");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "TiposInventario");
        }
    }
}
