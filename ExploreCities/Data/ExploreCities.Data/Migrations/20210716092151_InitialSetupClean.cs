namespace ExploreCities.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialSetupClean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MaterialLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityHistories_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityHistories_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UserCities",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCities", x => new { x.UserId, x.CityId });
                    table.ForeignKey(
                        name: "FK_UserCities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionViews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegionLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalYear = table.Column<int>(type: "int", nullable: false),
                    DepartureYear = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetLighting = table.Column<int>(type: "int", nullable: false),
                    StreetQuality = table.Column<int>(type: "int", nullable: false),
                    StreetPollution = table.Column<int>(type: "int", nullable: false),
                    ParkingSpaces = table.Column<int>(type: "int", nullable: false),
                    BikeArea = table.Column<int>(type: "int", nullable: false),
                    ChildrenPlaygrounds = table.Column<int>(type: "int", nullable: false),
                    AirPollution = table.Column<int>(type: "int", nullable: false),
                    Noise = table.Column<int>(type: "int", nullable: false),
                    PublicTransport = table.Column<int>(type: "int", nullable: false),
                    BusStationDistance = table.Column<double>(type: "float", nullable: false),
                    TrainStationDistance = table.Column<double>(type: "float", nullable: false),
                    MetroStationDistance = table.Column<double>(type: "float", nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionViews_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionViews_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRegions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegions", x => new { x.UserId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_UserRegions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discussions_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ObjectType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objects_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscussionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDiscussions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscussionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscussions", x => new { x.UserId, x.DiscussionId });
                    table.ForeignKey(
                        name: "FK_UserDiscussions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDiscussions_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ObjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ObjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_CityHistories_CityHistoryId",
                        column: x => x.CityHistoryId,
                        principalTable: "CityHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IsDeleted",
                table: "Cities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CityHistories_AddedByUserId",
                table: "CityHistories",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHistories_CityId",
                table: "CityHistories",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHistories_IsDeleted",
                table: "CityHistories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AddedByUserId",
                table: "Comments",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DiscussionId",
                table: "Comments",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RegionViewId",
                table: "Comments",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_RegionViewId",
                table: "Discussions",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_IsDeleted",
                table: "Objects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_RegionViewId",
                table: "Objects",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CityHistoryId",
                table: "Pictures",
                column: "CityHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_IsDeleted",
                table: "Pictures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ObjectId",
                table: "Pictures",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_RegionViewId",
                table: "Pictures",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CityId",
                table: "Regions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_AddedByUserId",
                table: "RegionViews",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_IsDeleted",
                table: "RegionViews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_RegionId",
                table: "RegionViews",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCities_CityId",
                table: "UserCities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscussions_DiscussionId",
                table: "UserDiscussions",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegions_RegionId",
                table: "UserRegions",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "UserCities");

            migrationBuilder.DropTable(
                name: "UserDiscussions");

            migrationBuilder.DropTable(
                name: "UserRegions");

            migrationBuilder.DropTable(
                name: "CityHistories");

            migrationBuilder.DropTable(
                name: "Objects");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "RegionViews");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AspNetUsers");
        }
    }
}
