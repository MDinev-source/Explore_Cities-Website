namespace ExploreCities.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddDistrictViewLikesDislikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "DistrictViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "DistrictViews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DistrictViewDislikes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DistrictViewId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictViewDislikes", x => new { x.UserId, x.DistrictViewId });
                    table.ForeignKey(
                        name: "FK_DistrictViewDislikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistrictViewDislikes_DistrictViews_DistrictViewId",
                        column: x => x.DistrictViewId,
                        principalTable: "DistrictViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistrictViewLikes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DistrictViewId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictViewLikes", x => new { x.UserId, x.DistrictViewId });
                    table.ForeignKey(
                        name: "FK_DistrictViewLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistrictViewLikes_DistrictViews_DistrictViewId",
                        column: x => x.DistrictViewId,
                        principalTable: "DistrictViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistrictViewDislikes_DistrictViewId",
                table: "DistrictViewDislikes",
                column: "DistrictViewId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictViewLikes_DistrictViewId",
                table: "DistrictViewLikes",
                column: "DistrictViewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistrictViewDislikes");

            migrationBuilder.DropTable(
                name: "DistrictViewLikes");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "DistrictViews");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "DistrictViews");
        }
    }
}
