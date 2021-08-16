using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExploreCities.Data.Migrations
{
    public partial class AddBaseDelPropAndPicturesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_CityArticles_CityArticleId",
                table: "Pictures");

            migrationBuilder.DropTable(
                name: "CityArticles");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_CityArticleId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CityArticleId",
                table: "Pictures");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserDistricts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserDistricts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UserDistricts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserDistricts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserDistricts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserCities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserCities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UserCities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserCities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserCities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "Pictures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DistrictViewLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "DistrictViewLikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "DistrictViewLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DistrictViewLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DistrictViewLikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DistrictViewDislikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "DistrictViewDislikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "DistrictViewDislikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DistrictViewDislikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DistrictViewDislikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "DistrictObjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DistrictLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "DistrictLikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "DistrictLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DistrictLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DistrictLikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDistricts_IsDeleted",
                table: "UserDistricts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserCities_IsDeleted",
                table: "UserCities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_AddedByUserId",
                table: "Pictures",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictViewLikes_IsDeleted",
                table: "DistrictViewLikes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictViewDislikes_IsDeleted",
                table: "DistrictViewDislikes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictObjects_AddedByUserId",
                table: "DistrictObjects",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictLikes_IsDeleted",
                table: "DistrictLikes",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictObjects_AspNetUsers_AddedByUserId",
                table: "DistrictObjects",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_AspNetUsers_AddedByUserId",
                table: "Pictures",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistrictObjects_AspNetUsers_AddedByUserId",
                table: "DistrictObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_AspNetUsers_AddedByUserId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_UserDistricts_IsDeleted",
                table: "UserDistricts");

            migrationBuilder.DropIndex(
                name: "IX_UserCities_IsDeleted",
                table: "UserCities");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_AddedByUserId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_DistrictViewLikes_IsDeleted",
                table: "DistrictViewLikes");

            migrationBuilder.DropIndex(
                name: "IX_DistrictViewDislikes_IsDeleted",
                table: "DistrictViewDislikes");

            migrationBuilder.DropIndex(
                name: "IX_DistrictObjects_AddedByUserId",
                table: "DistrictObjects");

            migrationBuilder.DropIndex(
                name: "IX_DistrictLikes_IsDeleted",
                table: "DistrictLikes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserDistricts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserDistricts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserDistricts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserDistricts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserDistricts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserCities");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserCities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserCities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserCities");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserCities");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DistrictViewLikes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "DistrictViewLikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DistrictViewLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DistrictViewLikes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DistrictViewLikes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DistrictViewDislikes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "DistrictViewDislikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DistrictViewDislikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DistrictViewDislikes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DistrictViewDislikes");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "DistrictObjects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DistrictLikes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "DistrictLikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DistrictLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DistrictLikes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DistrictLikes");

            migrationBuilder.AddColumn<string>(
                name: "CityArticleId",
                table: "Pictures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CityArticles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaterialLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityArticles_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityArticles_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CityArticleId",
                table: "Pictures",
                column: "CityArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CityArticles_AddedByUserId",
                table: "CityArticles",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CityArticles_CityId",
                table: "CityArticles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityArticles_IsDeleted",
                table: "CityArticles",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_CityArticles_CityArticleId",
                table: "Pictures",
                column: "CityArticleId",
                principalTable: "CityArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
