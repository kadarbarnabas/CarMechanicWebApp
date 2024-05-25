using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMechanic.Migrations
{
    /// <inheritdoc />
    public partial class CarMechanic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Ugyfelszam = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    Lakcim = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Ugyfelszam);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    MunkaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Ugyfelszam = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rendszam = table.Column<string>(type: "TEXT", nullable: false),
                    GyartasiEv = table.Column<int>(type: "INTEGER", nullable: false),
                    Kategoria = table.Column<string>(type: "TEXT", nullable: false),
                    HibakLeirasa = table.Column<string>(type: "TEXT", nullable: false),
                    HibaSulyossag = table.Column<int>(type: "INTEGER", nullable: false),
                    Allapot = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.MunkaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
