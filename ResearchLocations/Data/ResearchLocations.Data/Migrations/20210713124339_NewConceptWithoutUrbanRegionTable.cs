namespace ResearchLocations.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NewConceptWithoutUrbanRegionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UrbanRegions_UrbanRegionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegionViews_UrbanRegions_RegionId",
                table: "RegionViews");

            migrationBuilder.DropTable(
                name: "UrbanRegions");

            migrationBuilder.DropIndex(
                name: "IX_RegionViews_RegionId",
                table: "RegionViews");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UrbanRegionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "StreetLocation",
                table: "RegionViews");

            migrationBuilder.DropColumn(
                name: "UrbanRegionId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "RegionViews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionLocation",
                table: "RegionViews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RegionLocation",
                table: "RegionViews");

            migrationBuilder.AddColumn<string>(
                name: "RegionId",
                table: "RegionViews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "StreetLocation",
                table: "RegionViews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrbanRegionId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UrbanRegions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrbanRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrbanRegions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_RegionId",
                table: "RegionViews",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UrbanRegionId",
                table: "AspNetUsers",
                column: "UrbanRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UrbanRegions_CityId",
                table: "UrbanRegions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UrbanRegions_IsDeleted",
                table: "UrbanRegions",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UrbanRegions_UrbanRegionId",
                table: "AspNetUsers",
                column: "UrbanRegionId",
                principalTable: "UrbanRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegionViews_UrbanRegions_RegionId",
                table: "RegionViews",
                column: "RegionId",
                principalTable: "UrbanRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
