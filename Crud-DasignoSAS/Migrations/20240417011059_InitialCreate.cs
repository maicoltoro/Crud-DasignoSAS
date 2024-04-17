using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_DasignoSAS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "varchar(50)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Sueldo = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "Datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "Datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datos");
        }
    }
}
