namespace ExploreCities.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DeleteRegionLocationFromRegionViewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionLocation",
                table: "RegionViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegionLocation",
                table: "RegionViews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);
        }
    }
}
