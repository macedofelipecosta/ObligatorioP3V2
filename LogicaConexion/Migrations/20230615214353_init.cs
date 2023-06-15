using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaConexion.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabanas",
                columns: table => new
                {
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    HabilitadoAReservas = table.Column<bool>(type: "bit", nullable: false),
                    CapacidadHabitacion = table.Column<int>(type: "int", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabanas", x => x.NumeroHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoHuesped = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMantenimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    Operador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabanaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Cabanas_CabanaId",
                        column: x => x.CabanaId,
                        principalTable: "Cabanas",
                        principalColumn: "NumeroHabitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabanas_NumeroHabitacion",
                table: "Cabanas",
                column: "NumeroHabitacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_CabanaId",
                table: "Mantenimientos",
                column: "CabanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_Id",
                table: "Mantenimientos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_Nombre",
                table: "Tipos",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cabanas");
        }
    }
}
