namespace ExploreCities.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddRaitingPropertyToDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Raiting",
                table: "Districts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raiting",
                table: "Districts");
        }
    }
}
