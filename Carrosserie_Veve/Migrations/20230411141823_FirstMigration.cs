using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carrosserie_Veve.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HeureDebut = table.Column<string>(type: "TEXT", nullable: false),
                    HeureFin = table.Column<string>(type: "TEXT", nullable: false),
                    JourOff = table.Column<string>(type: "TEXT", nullable: false),
                    Vacances = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomPrestation = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Description_courte = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Realisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomRealisation = table.Column<string>(type: "TEXT", nullable: false),
                    ImageAvt = table.Column<string>(type: "TEXT", nullable: true),
                    ImageAvt2 = table.Column<string>(type: "TEXT", nullable: true),
                    ImageAp = table.Column<string>(type: "TEXT", nullable: true),
                    ImageAp2 = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realisations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horaires");

            migrationBuilder.DropTable(
                name: "Prestations");

            migrationBuilder.DropTable(
                name: "Realisations");
        }
    }
}
