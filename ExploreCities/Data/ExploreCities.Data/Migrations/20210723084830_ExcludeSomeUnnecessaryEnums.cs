namespace ExploreCities.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ExcludeSomeUnnecessaryEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BikeArea",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "BusStationDistance",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "MetroStationDistance",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "StreetLighting",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "StreetPollution",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "StreetQuality",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "TrainStationDistance",
                table: "RegionViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BikeArea",
                table: "RegionViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusStationDistance",
                table: "RegionViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MetroStationDistance",
                table: "RegionViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StreetLighting",
                table: "RegionViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StreetPollution",
                table: "RegionViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StreetQuality",
                table: "RegionViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainStationDistance",
                table: "RegionViews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
