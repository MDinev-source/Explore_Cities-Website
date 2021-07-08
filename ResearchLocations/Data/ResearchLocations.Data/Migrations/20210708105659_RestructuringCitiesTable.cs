using Microsoft.EntityFrameworkCore.Migrations;

namespace ResearchLocations.Data.Migrations
{
    public partial class RestructuringCitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionViews_Cities_CityId",
                table: "RegionViews");

            migrationBuilder.DropIndex(
                name: "IX_RegionViews_CityId",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "RegionViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "RegionViews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_CityId",
                table: "RegionViews",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionViews_Cities_CityId",
                table: "RegionViews",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
