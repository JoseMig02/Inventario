using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_TiposInventario_TipoInventarioId",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasXAlmacenes_Almacenes_AlmacenId",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasXAlmacenes_Articulos_ArticuloId",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Articulos_ArticuloId",
                table: "Transacciones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_ArticuloId",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasXAlmacenes_AlmacenId",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasXAlmacenes_ArticuloId",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_TipoInventarioId",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "ArticuloId",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "AlmacenId",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropColumn(
                name: "ArticuloId",
                table: "ExistenciasXAlmacenes");

            migrationBuilder.DropColumn(
                name: "TipoInventarioId",
                table: "Articulos");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TiposInventario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Almacenes",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Nombre",
                table: "TiposInventario");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Almacenes");

            migrationBuilder.AddColumn<int>(
                name: "ArticuloId",
                table: "Transacciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlmacenId",
                table: "ExistenciasXAlmacenes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticuloId",
                table: "ExistenciasXAlmacenes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoInventarioId",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ArticuloId",
                table: "Transacciones",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasXAlmacenes_AlmacenId",
                table: "ExistenciasXAlmacenes",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasXAlmacenes_ArticuloId",
                table: "ExistenciasXAlmacenes",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TipoInventarioId",
                table: "Articulos",
                column: "TipoInventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_TiposInventario_TipoInventarioId",
                table: "Articulos",
                column: "TipoInventarioId",
                principalTable: "TiposInventario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasXAlmacenes_Almacenes_AlmacenId",
                table: "ExistenciasXAlmacenes",
                column: "AlmacenId",
                principalTable: "Almacenes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasXAlmacenes_Articulos_ArticuloId",
                table: "ExistenciasXAlmacenes",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Articulos_ArticuloId",
                table: "Transacciones",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id");
        }
    }
}
