using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResearchLocations.Data.Migrations
{
    public partial class InitialViewOfLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionDescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetLighting = table.Column<int>(type: "int", nullable: false),
                    StreetQuality = table.Column<int>(type: "int", nullable: false),
                    StreetPollution = table.Column<int>(type: "int", nullable: false),
                    ParkingSpaces = table.Column<int>(type: "int", nullable: false),
                    BikeArea = table.Column<int>(type: "int", nullable: false),
                    ChildrenPlaygrounds = table.Column<int>(type: "int", nullable: false),
                    AirPollution = table.Column<int>(type: "int", nullable: false),
                    Noise = table.Column<int>(type: "int", nullable: false),
                    PublicTransport = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "RegionViews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreetLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfResidence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearOfDeparture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegionDescriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_RegionViews_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionViews_RegionDescriptions_RegionDescriptionId",
                        column: x => x.RegionDescriptionId,
                        principalTable: "RegionDescriptions",
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
                name: "CityHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_CityHistories_RegionViews_RegionViewId",
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
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_Comments_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Landmarks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landmarks_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markets_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NonStops",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonStops_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherObjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherObjects_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parks_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacies_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoliceStations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliceStations_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RetailParks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailParks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetailParks_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportHobbies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportHobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportHobbies_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StationType = table.Column<int>(type: "int", nullable: false),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PictureVideos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionViewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LandmarkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MarketId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NonStopId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OtherObjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PharmacyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PoliceStationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RetailParkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SchoolId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShopId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportHobbyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CityHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegionDescriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PictureVideos_CityHistories_CityHistoryId",
                        column: x => x.CityHistoryId,
                        principalTable: "CityHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_NonStops_NonStopId",
                        column: x => x.NonStopId,
                        principalTable: "NonStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_OtherObjects_OtherObjectId",
                        column: x => x.OtherObjectId,
                        principalTable: "OtherObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Parks_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_PoliceStations_PoliceStationId",
                        column: x => x.PoliceStationId,
                        principalTable: "PoliceStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_RegionDescriptions_RegionDescriptionId",
                        column: x => x.RegionDescriptionId,
                        principalTable: "RegionDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_RegionViews_RegionViewId",
                        column: x => x.RegionViewId,
                        principalTable: "RegionViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_RetailParks_RetailParkId",
                        column: x => x.RetailParkId,
                        principalTable: "RetailParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_SportHobbies_SportHobbyId",
                        column: x => x.SportHobbyId,
                        principalTable: "SportHobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureVideos_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers",
                column: "RegionId");

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
                name: "IX_CityHistories_RegionViewId",
                table: "CityHistories",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AddedByUserId",
                table: "Comments",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RegionViewId",
                table: "Comments",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_IsDeleted",
                table: "Hospitals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_RegionViewId",
                table: "Hospitals",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_IsDeleted",
                table: "Landmarks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_RegionViewId",
                table: "Landmarks",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_IsDeleted",
                table: "Markets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_RegionViewId",
                table: "Markets",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_NonStops_IsDeleted",
                table: "NonStops",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_NonStops_RegionViewId",
                table: "NonStops",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherObjects_IsDeleted",
                table: "OtherObjects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OtherObjects_RegionViewId",
                table: "OtherObjects",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_IsDeleted",
                table: "Parks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_RegionViewId",
                table: "Parks",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_IsDeleted",
                table: "Pharmacies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_RegionViewId",
                table: "Pharmacies",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_CityHistoryId",
                table: "PictureVideos",
                column: "CityHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_HospitalId",
                table: "PictureVideos",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_IsDeleted",
                table: "PictureVideos",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_LandmarkId",
                table: "PictureVideos",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_MarketId",
                table: "PictureVideos",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_NonStopId",
                table: "PictureVideos",
                column: "NonStopId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_OtherObjectId",
                table: "PictureVideos",
                column: "OtherObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_ParkId",
                table: "PictureVideos",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_PharmacyId",
                table: "PictureVideos",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_PoliceStationId",
                table: "PictureVideos",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_RegionDescriptionId",
                table: "PictureVideos",
                column: "RegionDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_RegionViewId",
                table: "PictureVideos",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_RestaurantId",
                table: "PictureVideos",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_RetailParkId",
                table: "PictureVideos",
                column: "RetailParkId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_SchoolId",
                table: "PictureVideos",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_ShopId",
                table: "PictureVideos",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_SportHobbyId",
                table: "PictureVideos",
                column: "SportHobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureVideos_StationId",
                table: "PictureVideos",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceStations_IsDeleted",
                table: "PoliceStations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceStations_RegionViewId",
                table: "PoliceStations",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionDescriptions_IsDeleted",
                table: "RegionDescriptions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CityId",
                table: "Regions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_IsDeleted",
                table: "Regions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_AddedByUserId",
                table: "RegionViews",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_CityId",
                table: "RegionViews",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_IsDeleted",
                table: "RegionViews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_RegionDescriptionId",
                table: "RegionViews",
                column: "RegionDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionViews_RegionId",
                table: "RegionViews",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_IsDeleted",
                table: "Restaurants",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RegionViewId",
                table: "Restaurants",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_RetailParks_IsDeleted",
                table: "RetailParks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RetailParks_RegionViewId",
                table: "RetailParks",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_IsDeleted",
                table: "Schools",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_RegionViewId",
                table: "Schools",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_IsDeleted",
                table: "Shops",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_RegionViewId",
                table: "Shops",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_SportHobbies_IsDeleted",
                table: "SportHobbies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SportHobbies_RegionViewId",
                table: "SportHobbies",
                column: "RegionViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_IsDeleted",
                table: "Stations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RegionViewId",
                table: "Stations",
                column: "RegionViewId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PictureVideos");

            migrationBuilder.DropTable(
                name: "CityHistories");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Landmarks");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "NonStops");

            migrationBuilder.DropTable(
                name: "OtherObjects");

            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "PoliceStations");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "RetailParks");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "SportHobbies");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "RegionViews");

            migrationBuilder.DropTable(
                name: "RegionDescriptions");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "AspNetUsers");
        }
    }
}
