using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablashhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_TiposInventario_IdentificadorTipoInventario",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasXAlmacenes_Almacenes_IdAlmacen",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasXAlmacenes_Articulos_IdArticulo",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Articulos_IdArticulo",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_IdArticulo",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasXAlmacenes_IdAlmacen",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasXAlmacenes_IdArticulo",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_IdentificadorTipoInventario",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "TiposInventario");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "TiposInventario");

            migrationBuilder.DropColumn(
                name: "FechaUltimaActualizacion",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Almacenes");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Almacenes");

            migrationBuilder.RenameColumn(
                name: "IdentificadorTipoInventario",
                table: "Articulos",
                newName: "IdTipoInventario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTipoInventario",
                table: "Articulos",
                newName: "IdentificadorTipoInventario");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "TiposInventario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "TiposInventario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUltimaActualizacion",
                table: "ExistenciasXAlmacenes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Almacenes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Almacenes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdArticulo",
                table: "Transacciones",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasXAlmacenes_IdAlmacen",
                table: "ExistenciasXAlmacenes",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasXAlmacenes_IdArticulo",
                table: "ExistenciasXAlmacenes",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdentificadorTipoInventario",
                table: "Articulos",
                column: "IdentificadorTipoInventario");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_TiposInventario_IdentificadorTipoInventario",
                table: "Articulos",
                column: "IdentificadorTipoInventario",
                principalTable: "TiposInventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasXAlmacenes_Almacenes_IdAlmacen",
                table: "ExistenciasXAlmacenes",
                column: "IdAlmacen",
                principalTable: "Almacenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasXAlmacenes_Articulos_IdArticulo",
                table: "ExistenciasXAlmacenes",
                column: "IdArticulo",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Articulos_IdArticulo",
                table: "Transacciones",
                column: "IdArticulo",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
