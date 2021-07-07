namespace ResearchLocations.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CityTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegionViews_Regions_RegionId",
                table: "RegionViews");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Cities",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "AspNetUsers",
                newName: "UrbanRegionId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UrbanRegionId");

            migrationBuilder.CreateTable(
                name: "UrbanRegions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UrbanRegions_UrbanRegionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegionViews_UrbanRegions_RegionId",
                table: "RegionViews");

            migrationBuilder.DropTable(
                name: "UrbanRegions");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Cities",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "UrbanRegionId",
                table: "AspNetUsers",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UrbanRegionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RegionId");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CityId",
                table: "Regions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_IsDeleted",
                table: "Regions",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegionViews_Regions_RegionId",
                table: "RegionViews",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
