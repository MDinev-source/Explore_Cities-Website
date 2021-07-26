namespace ExploreCities.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NamesCorrectionToCityAndOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Cities",
                newName: "Area");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Cities",
                newName: "Region");
        }
    }
}
