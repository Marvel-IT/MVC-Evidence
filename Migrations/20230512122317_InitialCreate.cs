using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEvidence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Jmeno = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Prijmeni = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Vek = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefon = table.Column<int>(type: "INTEGER", nullable: false),
                    Pojistovna = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osoba");
        }
    }
}
